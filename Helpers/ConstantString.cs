namespace ReactApi.Helpers
{
    /// <summary>
    /// Common messages
    /// </summary>
    public static class CommonErrorMessages
    {
        /// <summary>
        /// UnknownError
        /// </summary>
        public const string UnknownError = "Sorry, we have encountered an error.";

        /// <summary>
        /// BadRequest
        /// </summary>
        public const string BadRequest = "Invalid Request";

        /// <summary>
        /// NoResultFound
        /// </summary>
        public const string NoResultFound = "No Result Found";

        /// <summary>
        /// SomethingWentWrong
        /// </summary>
        public const string SomethingWentWrong = "Some thing went wrong";
    }

    /// <summary>
    /// Application constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Added By Column
        /// </summary>
        public const string CreatedBy = "CreatedBy";

        /// <summary>
        /// Added Date Column
        /// </summary>
        public const string CreatedDate = "CreatedDate";

        /// <summary>
        /// The modified by column
        /// </summary>
        public const string ModifiedBy = "ModifiedBy";

        /// <summary>
        /// The modified date column
        /// </summary>
        public const string ModifiedDate = "ModifiedDate";

        /// <summary>
        /// limited collaborator to be shown
        /// </summary>
        public const int FilterCollaboratorCount = 4;

    }
   
    /// <summary>
    /// Control Types
    /// </summary>
    public static class ControlTypes
    {
        /// <summary>
        /// Title Type
        /// </summary>
        public const string Title = "title";

        /// <summary>
        /// SubTitle Type
        /// </summary>
        public const string SubTitle = "subtitle";

        /// <summary>
        /// Image Type
        /// </summary>
        public const string Image = "img";

        /// <summary>
        /// TimeLine Type
        /// </summary>
        public const string TimeLine = "timeline";

        /// <summary>
        /// Description Type
        /// </summary>
        public const string Description = "desc";

    }
    
    /// <summary>
    /// Email template path
    /// </summary>
    public static class EmailTemplatePath
    {
        /// <summary>
        /// Proposal mail template path
        /// </summary>
        public const string Proposal = "";
    }

    /// <summary>
    /// Messages reslated to file action
    /// </summary>
    public static class FileActionMessages
    {
        /// <summary>
        /// FileCoverPhoto key
        /// </summary>
        public const string CoverPhotoKey = "cover_Photo";

        /// <summary>
        /// No file matched during file upload
        /// </summary>
        public const string NoFileMatch = "File uploaded does not match image in Proposal Category Control while adding new proposal";

        /// <summary>
        /// No category found during file upload
        /// </summary>
        public const string CategoryNotFound = "Proposal Category could not be found in proposal model while adding new proposal";


    }
}
