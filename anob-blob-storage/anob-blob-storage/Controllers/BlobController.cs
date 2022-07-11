using anob_blob_storage.Services;
using Microsoft.AspNetCore.Mvc;

namespace anob_blob_storage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlobController : Controller
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService)
        {
            _blobService = blobService ?? throw new ArgumentNullException(nameof(IBlobService));
        }

        [HttpGet("GetBlobs")]
        public async Task<IActionResult> Get()
        {
            var blobs = await _blobService.ReturnAllFilesAsync();
            return new JsonResult(blobs);
        }
    }
}

