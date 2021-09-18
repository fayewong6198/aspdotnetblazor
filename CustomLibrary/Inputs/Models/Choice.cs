namespace aspnetblazor.CustomLibrary.Inputs.Models
{
    public class Choice
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public Choice(string label, string value)
        {
            this.Label = label;
            this.Value = value;
        }
    }
}