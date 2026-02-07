namespace FilmlisteApp.Models;

public class Film
{
    public int Id { get; set; }
    public string? Tittel { get; set; }
    public string? Sjanger { get; set; }
    public int? Utgitt { get; set; }
    public string? Beskrivelse { get; set; }
}
