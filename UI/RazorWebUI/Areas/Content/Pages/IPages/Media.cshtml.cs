using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net.Http.Headers;

namespace RazorWebUI.Areas.Content.Pages.IPages
{
    public class MediaModel : PageModel
    {
        private readonly AppDbContext _context;
        private const int PageSize = 20; // Number of items per page

        public MediaModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<MediaDto> MediaDtos { get; set; } = new List<MediaDto>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int page = 1)
        {
            CurrentPage = page;

            // Fetch all necessary data from the database
            var webPages = await _context.WebPages.ToListAsync();
            var sectionPages = await _context.PageSections.ToListAsync();
            var sectionListPages = await _context.PageSectionLists.ToListAsync();
            var sliders = await _context.Sliders.ToListAsync();
            var blogs = await _context.Blogs.ToListAsync();

            var allItems = new List<dynamic>();

            // Aggregate all items into a single list
            allItems.AddRange(webPages.Select(wp => new { wp.Title, wp.ImageUrl, Route = "Web Page" }));
            allItems.AddRange(sectionPages.Select(sp => new { sp.Title, sp.ImageUrl, Route = $"Page Section ({sp.WebPageId})" }));
            allItems.AddRange(sectionListPages.Select(slp => new { slp.Title, slp.ImageUrl, Route = $"Page Section List ({slp.PageSectionId})" }));
            allItems.AddRange(sliders.Select(sl => new { sl.Title, ImageUrl = sl.Url, Route = "Slider" }));
            allItems.AddRange(blogs.Select(b => new { b.Title, b.ImageUrl, Route = "Blog" }));

            // Filter out items with null ImageUrl
            allItems = allItems.Where(item => !string.IsNullOrWhiteSpace(item.ImageUrl)).ToList();

            // Pagination logic
            TotalPages = (int)Math.Ceiling(allItems.Count / (double)PageSize);
            var pagedItems = allItems.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Process only the paginated items
            var mediaDtos = new List<MediaDto>();
            foreach (var item in pagedItems)
            {
                var mediaDto = new MediaDto
                {
                    Title = item.Title,
                    Route = item.Route,
                    ImageUrl = item.ImageUrl,
                    ImageSize = await GetImageDetailsAsync(item.ImageUrl),
                };

                mediaDtos.Add(mediaDto);
            }

            MediaDtos = mediaDtos;
        }

        private async Task<string?> GetImageDetailsAsync(string? imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return null;

            try
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
                using var response = await httpClient.GetAsync(imageUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the image stream and get its size in bytes
                    await using var stream = await response.Content.ReadAsStreamAsync();
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);

                    var imageSizeInBytes = memoryStream.Length;
                    var imageSizeInKb = imageSizeInBytes / 1024.0;

                    // Load the image to get dimensions
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using var image = Image.FromStream(memoryStream);

                    return $"{imageSizeInKb:F2} KB, {image.Width}x{image.Height}";
                }
            }
            catch
            {
                // Log error if needed
                return null;
            }

            return null;
        }
    }

    public class MediaDto
    {
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageSize { get; set; }
        public string? Route { get; set; }
        public string? Link { get; set; }

    }
}
