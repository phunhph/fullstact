namespace fullstackCsharp.Models
{
    public class Staff
    {
        public string id_NV;
        public string name_NV;
        public string dob_NV;
        public string sex;
        public string id_PB0;
        public string name_PB;
       public Staff(string id_NV, string name_NV, string dob_NV, string sex, string id_PB0, string name_PB)
        {
            this.id_NV = id_NV;
            this.name_NV = name_NV;
            this.dob_NV = dob_NV;
            this.sex = sex;
            this.id_PB0 = id_PB0;
            this.name_PB = name_PB;
        }
    }
}
