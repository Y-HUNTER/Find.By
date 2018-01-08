namespace Find.By.Server
{
    internal class Status
    {
        public string Value { get; private set; }

        public static Status Ok 
        {
            get
            {
                return new Status() {Value = "Ok"};
            }
        }

        public static Status Empty
        {
            get
            {
                return new Status() {Value = "Empty"};
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}