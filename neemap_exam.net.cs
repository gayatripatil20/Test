
string connectionString = "Data Source=ServerName;Initial Catalog=DatabaseName;Integrated Security=True;";
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

public class DataAccessLayer
{
    private SqlConnection connection;

    public DataAccessLayer(SqlConnection connection)
    {
        this.connection = connection;
    }

    public void InsertData(string name, int age)
    {
        SqlCommand command = new SqlCommand("INSERT INTO Person (Name, Age) VALUES (@Name, @Age)", connection);
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Age", age);
        command.ExecuteNonQuery();
    }

    public DataTable GetData()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM Person", connection);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        return dataTable;
    }

    public void UpdateData(int id, string name, int age)
    {
        SqlCommand command = new SqlCommand("UPDATE Person SET Name = @Name, Age = @Age WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Age", age);
        command.ExecuteNonQuery();
    }

    public void DeleteData(int id)
    {
        SqlCommand command = new SqlCommand("DELETE FROM Person WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

DataAccessLayer dal = new DataAccessLayer(connection);

public void CreatePerson(string name, int age)
{
    dal.InsertData(name, age);
}

public List<Person> ReadPeople()
{
    DataTable dataTable = dal.GetData();
    List<Person> people = new List<Person>();
    foreach (DataRow row in dataTable.Rows)
    {
        Person person = new Person();
        person.Id = (int)row["Id"];
        person.Name = row["Name"].ToString();
        person.Age = (int)row
    }
}
