namespace Models
{
    public class Insurance
    {
        public string provider { get; set; }
        public string benefactor { get; set; }

        public insurance()
        {
             provider = null;
             benefactor= null;
             
        }
        // Used for creating a new insurace class
        public Insurance(string provider, string benefactor)
        {
            this.provider = provider;
            this.benefactor = benefactor;
        }
        // Used for getting all insurance
        public Insurance(string provider, string benefactor)
        {
            this.provider = provider;
            this.benefactor = benefactor;
        }
    }
}
