using System.IO;
using System.Data.SQLite;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void Display()
    {
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string file)
    {
        string fileName = file;

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"Date:{e._date}-Prompt:{e._promptText}-{e._entryText}");
            }
        }
    }

    public void loadFromFile(string file)
    {
        string fileName = file;
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("-");

            string date = parts[0];
            string prompt = parts[1];
            string entryText = parts[2];
            Entry e = new Entry();
            e._date = date;
            e._promptText = prompt;
            e._entryText = entryText;
            _entries.Add(e);

        }
    }

    public void SaveToDatabase(string connectionString)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Entries(
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Date TEXT,
            Prompt TEXT,
            EntryText TEXT
            );";
            using (var command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            foreach (Entry e in _entries)
            {
                string insertQuery = "INSERT INTO Entries (Date,Prompt,EntryText) VALUES (@Date, @Prompt , @EntryText);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Date", e._date);
                    command.Parameters.AddWithValue("@Prompt", e._promptText);
                    command.Parameters.AddWithValue("@EntryText", e._entryText);
                    command.ExecuteNonQuery();
                }

            }
        }
    }

    public void LoadFromDatabase(string connectionString)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT Date, Prompt, EntryText FROM Entries;";
            using (var command = new SQLiteCommand(selectQuery, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Entry e = new Entry();
                    e._date = reader["Date"].ToString();
                    e._promptText = reader["Prompt"].ToString();
                    e._entryText = reader["EntryText"].ToString();
                    _entries.Add(e);
                }
            }

        }
    }

}
