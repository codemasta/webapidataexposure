using System.Collections.Generic;

namespace BlogPost.Data
{
    public class DataRepository
    {
        public static IList<Data> GetData()
        {
            return new List<Data>()
            {
                new Data(){ Age = 45, Sex = "Male" , Name = "Adeyinka Oluwaseun", PhoneNumber = "1111"},
                new Data(){ Age = 23, Sex = "Female" , Name = "Doyin Solomon", PhoneNumber = "2222"},
                new Data(){ Age = 56, Sex = "Male" , Name = "John Doe", PhoneNumber = "3333"},
            };
        }
    }

    public class Data
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }

}
