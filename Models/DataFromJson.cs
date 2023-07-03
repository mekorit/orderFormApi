using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class DataFromJson
    {
        public string branch { get; set; } = "";

        public string branchName { get; set; } = "";
        public string branchAdress { get; set; } = "";

        public string branchPhone1 { get; set; } = "";
        public string branchPhone2 { get; set; } = "";
        public string tel2 { get; set; } = "";
        public string tel1 { get; set; } = "";
        public string city { get; set; } = "";
        public string street { get; set; } = "";
        public string mail { get; set; } = "";
        public string fromMail { get; set; } = "";
        public string lastName { get; set; } = "";
        public string firstName { get; set; } = "";
       
        public string Subject { get; set; } = "";

        public string TextBody { get; set; } = "";

        public double totalPriceOrder { get; set; } = 0;
        public string tableItemsOrdered { get; set; } = "";

        public List<OrderDetail> orderDetails { get; set; }
    }
    public class OrderDetail
    {
        public string coverNumber { get; set; } = "";
        public string globalName { get; set; } = "";
        public string letter { get; set; } = "";
        public string BooksNum { get; set; } = "";
        public string notBooksNum { get; set; } = "";
        public string personalName { get; set; } = "";
        public bool personalNameForBook { get; set; } = false;
        public bool personalNameForNotBook { get; set; } = false;

        public string font { get; set; } = "";
        public string color { get; set; } = "";
        public string colorNumber { get; set; } = "";

        public bool booksEnglish { get; set; } = false;
        public bool notBooksEnglish { get; set; } = false;
        public string personalNameEnglish { get; set; } = "";
        public string fontEnglish { get; set; } = "";
        public string colorEnglish { get; set; } = "";
        public string colorNumberEnglish { get; set; } = "";
        public double totalPrice { get; set; } = 0;
        public string remark { get; set; } = "";

    }

}
