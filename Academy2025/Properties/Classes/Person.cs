namespace Properties.Classes
{
    public class Person
    {
        //public static int StaticProp { get; set; } = 1000;
        //public const string StaticField = "MyConfigValue";
        //public readonly string ReadOnlyField;

        //public Person()
        //{
        //    ReadOnlyField = StaticField;
        //}

        private int myVar;
        public int MyProperty
        {
            get
            {
                if (myVar == 0)
                    return 100;

                return myVar;
            }
            private set
            {
                myVar = value;
            }
        }

        public required string Name { get; set; }
        public required string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;

        public void SetMyProp(int value)
        {
            MyProperty = value;
        }
    }
}
