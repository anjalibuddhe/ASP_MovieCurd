using System.Data.SqlClient;

namespace ASPMovieCurd.Models
{
    public class MovieCurd
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public  MovieCurd(IConfiguration configuration) {
        
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("DbConnection"));


        }
        public IEnumerable<Movie> GetAllMovies()
        {
            List<Movie> list = new List<Movie>();
            String qry = "select * from Movie";
            cmd=new SqlCommand(qry, con);
            con.Open();
            dr= cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Movie m = new Movie();
                    m.Id = Convert.ToInt32(dr["id"]);
                    m.Name = dr["name"].ToString();
                    m.ReleaseDate = Convert.ToDateTime(dr["releasedate"]);
                    m.Type= dr["type"].ToString();
                    m.Stars = dr["stars"].ToString();
                    list.Add(m);

                }
            }
            con.Close();
            return list;
        }



        public Movie GetMovieById(int id)
        {
            Movie m = new Movie();
            string qry = "select * from Movie where id=@id";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr= cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    m.Id = Convert.ToInt32(dr["id"]);
                    m.Name = dr["name"].ToString();
                    m.ReleaseDate = Convert.ToDateTime(dr["releasedate"]);
                    m.Type = dr["type"].ToString();
                    m.Stars = dr["stars"].ToString();
                }
            }
            con.Close();
            return m;
        }


        public int AddMovie(Movie movie)
        {
            int result = 0;
            string qry = "insert into Movie values(@name,@releasedate,@type,@stars)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", movie.Name);
            cmd.Parameters.AddWithValue("@releasedate",movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@type", movie.Type);
            cmd.Parameters.AddWithValue("@stars", movie.Stars);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateBook(Movie movie)
        {
            int result = 0;
            string qry = "update Movie set name=@name,releasedate=@releasedate,type=@type,stars=@stars";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", movie.Name);
            cmd.Parameters.AddWithValue("@releasedate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@type", movie.Type);
            cmd.Parameters.AddWithValue("@stars", movie.Stars);
            cmd.Parameters.AddWithValue("@id", movie.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int DeleteMovies(int id)
        {
            int result = 0;
            string qry = "delete from Movie where id=@id";
            cmd = new SqlCommand(qry, con);
            
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
    }
}

