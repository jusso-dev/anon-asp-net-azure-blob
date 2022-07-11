namespace anob_blob_storage.Models
{
    /// <summary>
    /// Returned from the <see cref="Controllers.BlobController"/>
    /// </summary>
	public class BlobFile
	{
        public string Title { get; set; }
        public string URL { get; set; }
    }
}

