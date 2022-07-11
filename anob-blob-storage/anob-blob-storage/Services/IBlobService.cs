using anob_blob_storage.Models;

namespace anob_blob_storage.Services
{
	public interface IBlobService
	{
        Task<List<BlobFile>> ReturnAllFilesAsync();
    }
}

