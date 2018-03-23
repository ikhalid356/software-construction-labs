package labsixt2;
import java.sql.*;
import java.util.Scanner;

public class LabSixt2 {

    // DB Constants
    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";  
    static final String DB_URL = "jdbc:mysql://localhost/University";
    static final String USER = "root";
    static final String PASS = "1234";
    
    // Function to print data from MySQL's ResultSet
    public static void print_data(ResultSet res) throws SQLException{
        while(res.next()){
            System.out.print("ID: " + res.getInt("ID"));
            System.out.print(", Registration no: " + res.getInt("RegNo"));
            System.out.print(", Name: " + res.getString("Name"));
            System.out.print(", Section: " + res.getString("Section"));
            System.out.print(", Contact: " + res.getString("Contact"));
            System.out.print(", Address: " + res.getString("Address"));
            System.out.println("");
        }
    }
    
    // Function to fetch all data from Student table
    public static void display_data(Connection conn) throws SQLException{
        Statement st = conn.createStatement();
        ResultSet res  = st.executeQuery("SELECT * FROM Student");
        print_data(res);
    }
    
    // Function to fetch records matching a specific registration num from 
    // the Student table
    public static void search_record(Connection conn) throws SQLException{
        Statement st = conn.createStatement();
        Scanner inp = new Scanner(System.in);
        System.out.println("Enter the Registration number to search: ");
        ResultSet res  = st.executeQuery("SELECT * FROM Student WHERE RegNo=" 
                                         + inp.nextLine());
        print_data(res);
    }
    
    // Function to delete record matching a specific ID num from 
    // the Student table
    public static void delete_record(Connection conn) throws SQLException{
        Statement st = conn.createStatement();
        Scanner inp = new Scanner(System.in);
        System.out.println("Enter the ID to delete: ");
        st.executeUpdate("DELETE from Student where ID=" + inp.nextLine());
        display_data(conn);
    }    
    
    // Main Function
    public static void main(String[] args) {
        try{
            Scanner input = new Scanner(System.in);
            //Register JDBC driver
            Class.forName(JDBC_DRIVER);
            //Open a connection
            Connection conn = DriverManager.getConnection(DB_URL, USER, PASS);
            // Keep looping (PoC)
            while(true){
                System.out.println("1)Display all Data");
                System.out.println("2)Search Record");
                System.out.println("3)Delete Record");
                String choice =  input.nextLine(); 
                if (choice.equals("1"))
                    display_data(conn);
                else if(choice.equals("2"))
                    search_record(conn);
                else if (choice.equals("3"))
                    delete_record(conn);
                else
                    System.out.println("Incorrect input");
            }
           }
        // Generic Catch-all
        catch(Exception e){
            e.printStackTrace();
        }
    }
    
}

