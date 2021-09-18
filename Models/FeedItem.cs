using System.ComponentModel.DataAnnotations;

namespace aspnetblazor.Models
{
    public class FeedItem
    {
        Feed Feed {get;set;}
        int FeedId {get;set;}
        string Data {get;set;}
        string Url {get;set;}

    }
}