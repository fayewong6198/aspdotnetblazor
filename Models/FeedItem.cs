using System.ComponentModel.DataAnnotations;

namespace aspnetblazor.Models
{
    public class FeedItem
    {
        public int Id {get;set;}
        public Feed Feed {get;set;}
        public int FeedId {get;set;}
        public string Data {get;set;}
        public string Url {get;set;}

    }
}