package lab8;
import java.sql.*;
import java.util.UUID;

public class Lab8 {

    // DB Constants
    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";  
    static final String DB_URL = "jdbc:mysql://localhost/lab8";
    static final String USER = "root";
    static final String PASS = "1234";
    
    // Function to execute the same statement using different ways
    // Type=1 Statement
    // Type=2 PreparedStatement
    // Type=3 Batch Update using Statement
    public static void use_stmt(Connection conn, int type) throws SQLException{
        Statement st = null;
        if (type==1 || type==3)
            st = conn.createStatement();
        else if (type==2)
            st = conn.prepareStatement("INSERT INTO student (Name, RegNo, Semester, Address) VALUES (?, ?, ?, ?)");
        int reg = 0; 
        String address = "Parker street";
        String semester = "5th";
        for (int i=0; i <=5000; i++){
            String name = UUID.randomUUID().toString();
            reg = reg + 1;
            if (type == 1)
                st.executeUpdate("INSERT INTO student (Name, RegNo, Semester, Address) VALUES ('" + name + "','" + reg + "','" + semester + "','" + address + "')");
            else if (type == 2){
                // Cast back to PreparedStatement
                ((PreparedStatement)st).setString(1, name);
                ((PreparedStatement)st).setInt(2, reg);
                ((PreparedStatement)st).setString(3, semester);
                ((PreparedStatement)st).setString(4, address);
                ((PreparedStatement)st).executeUpdate();
            }
            else if (type == 3)
                st.addBatch("INSERT INTO student (Name, RegNo, Semester, Address) VALUES ('" + name + "','" + reg + "','" + semester + "','" + address + "')");
        }
        if (type == 3)
            st.executeBatch();
        st.close();
    }
    
    public static void execute_tasks(Connection conn) throws SQLException{
        Statement st = conn.createStatement();
        //Task 1
        long startTime = System.nanoTime();
        use_stmt(conn, 1);
        long endTime   = System.nanoTime();
        System.out.println("Statement - autocommit: " + (endTime - startTime)/1000000000 + " seconds");
        st.executeUpdate("truncate student");

        //Task 2
        startTime = System.nanoTime();
        use_stmt(conn, 2);
        endTime   = System.nanoTime();
        System.out.println("PreparedStatement - autocommit: " + (endTime - startTime)/1000000000 + " seconds");
        st.executeUpdate("truncate student");

        //Task 3
        startTime = System.nanoTime();
        use_stmt(conn, 3);
        endTime   = System.nanoTime();
        System.out.println("Batch update - autocommit: " + (endTime - startTime)/1000000000 + " seconds");
        st.executeUpdate("truncate student");
    }
   
// Main Function
    public static void main(String[] args) {
        try{
            //Register JDBC driver
            Class.forName(JDBC_DRIVER);
            //Open a connection
            Connection conn = DriverManager.getConnection(DB_URL, USER, PASS);
            
            // Run with auto commit
            execute_tasks(conn);
            
            // Turn off auto commit
            conn.setAutoCommit(false);
            execute_tasks(conn);
           }
        // Generic Catch-all
        catch(Exception e){
            e.printStackTrace();
        }
    }
    
}
