package lab7combo;

import java.sql.*;
import java.util.Scanner;

/**
 *
 * @author dell
 */
public class lab7combo {

    // DB Constants
    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";  
    static final String DB_URL = "jdbc:mysql://localhost/new11";
    static final String USER = "root";
    static final String PASS = "seecs123";
    
    public static void main(String[] args) {
        try{
            Scanner input = new Scanner(System.in);
            // Register JDBC driver
            Class.forName(JDBC_DRIVER);
            // Open a connection
            Connection conn = DriverManager.getConnection(DB_URL, USER, PASS);
            // Keep looping
            while(true){
                System.out.println("1)Login");
                System.out.println("2)Register");
                System.out.println("3)I am a customer");
                String choice =  input.nextLine(); 
                if (choice.equals("1"))
                    login(conn);
                else if(choice.equals("2"))
                    register(conn);
                else if(choice.equals("3"))
                    return; //TODO DUA'S FUNCTION
                else
                    System.out.println("Incorrect input");
            }
           }
        // Generic Catch-all
        catch(Exception e){
            e.printStackTrace();
        }
    }

    // Handles logging in. Redirects to view according to user type.
    public static void login(Connection conn) throws SQLException{
        Scanner input = new Scanner(System.in);
        System.out.println("Username:");
        String inp =  input.nextLine(); 
        System.out.println("Password:");
        String inp1 =  input.nextLine(); 
        Statement st = conn.createStatement();
        ResultSet res  = st.executeQuery("SELECT * FROM user WHERE Email=\"" + inp + "\"");
        if(res.next()){
            if(inp1.equals(res.getString("Pass"))){
                String userType = res.getString("UType");
                if (userType.equals("staff") || userType.equals("admin"))
                    //TODO KHALID'S FUNCTION
                    Staff_view(conn);
                else if (userType.equals("owner"))
                    owner_view(conn);
            }
        }
        else{
            System.out.println("Incorrect Username or Password");
        }
    }
    
    // Handles registration of users and assigns them the type
    // Redirects to view according to user type
    public static void register(Connection conn) throws SQLException{
        Scanner input = new Scanner(System.in);
        System.out.println("Username:");
        String inp =  input.nextLine(); 
        System.out.println("Password:");
        String inp1 =  input.nextLine();
        System.out.println("User Type: 1)Admin 2)Staff 3)Owner");
        String inp2 =  input.nextLine();
        if (inp2.equals("1"))
            inp2 = "admin";
        else if(inp2.equals("2"))
            inp2 = "staff";
        else if(inp2.equals("3"))
            inp2 = "owner";
        else
        {
            System.out.println("Incorrect input");
            return;
        }
        Statement st = conn.createStatement();
        ResultSet res  = st.executeQuery("SELECT * FROM user WHERE Email=\"" + inp + "\"");
        // Check if user doesnt already exist
        if(!res.next()){
            st.executeUpdate("INSERT INTO `user` (Email, Pass, UType) VALUES ('" + inp+ "','" + inp1 + "','" + inp2 + "')");
            String userType = inp2;
            if (userType.equals("staff") || userType.equals("admin"))
                 //TODO KHALID'S FUNCTION
                Staff_view(conn);
            else if (userType.equals("owner"))
                owner_view(conn);
            }
        else
            System.out.println("Username or password already exist");
    }
    
    // Shows the store owner's view
    public static void owner_view(Connection conn) throws SQLException{
        Statement st = conn.createStatement();
        ResultSet res  = st.executeQuery("SELECT * FROM Orders;");
        while(res.next()){
            System.out.print("Order ID: " + res.getInt("OrderID"));
            System.out.print(", Food ID: " + res.getInt("FoodID"));
            System.out.print(", Price: " + res.getInt("Price"));
            System.out.print(", Order Type: " + res.getString("OType"));
            System.out.print(", Address: " + res.getString("Address"));
            System.out.print(", Completion Status: " + res.getString("IsComplete"));
            System.out.println("");
        }
        
        res  = st.executeQuery("SELECT count(*) FROM Orders;");
        if(res.next())
            System.out.print("Total Orders: " + res.getInt("count(*)"));
        System.out.println("");
    }
    

    


//Khalidpart

   
    public static void Staff_view(Connection conn) {
        loop: while(true){
        System.out.println("1- To Display Food Items");
        System.out.println("2- To Add Food Items");
        System.out.println("3- To Delete Food Items");
        System.out.println("4- To Mark Order Complete");
        System.out.println("5- To display Incomplete Orders");
        System.out.println("0- To Terminate");
       
        Scanner in = new Scanner(System.in); 
        System.out.println("Please Select from the Above Options:");
        int ch = in.nextInt();
        
    
        switch(ch)
        {
             case 0: {
                break loop;
            }
            case 1: {
                
                //displayFoodItems();
                   
        try{
            System.out.println("Connected:");
            Statement stm = (Statement) conn.createStatement();
            String sql= "Select FoodID, FName, Price from Food";
            ResultSet rs= stm.executeQuery(sql);
            while (rs.next()){
                System.out.print(rs.getString("FoodID"));
                System.out.print(" | ");
                System.out.print(rs.getString("Fname"));
                System.out.print(" | ");
                System.out.print(rs.getString("Price"));
                System.out.println("");
            }
        
        }
        catch (SQLException e){
            System.err.println(e);
            }
      
                break;
            }
    
            case 2: {
                //AddFood();
                  try{
             Statement stm = (Statement) conn.createStatement();
             Scanner input = new Scanner(System.in);
             System.out.println("Enter The Food Name to Add the Item : ");
             String fname = input.nextLine(); 
             System.out.println("Enter The Food Price: ");
             String price = input.nextLine();
             
             String sql = "INSERT INTO `food` (FName, Price) VALUES ('" +
                    fname + "','" + price + "');";
            stm.executeUpdate(sql);
             System.out.println("Success'!");
    }
    
     catch (SQLException e){
            System.err.println(e);
        }
                break;
            }
            case 3: {
                //DeleteItem();
                try{
             Statement stm = (Statement) conn.createStatement();
             Scanner input = new Scanner(System.in);
             System.out.println("Enter The Food ID to Delete the Item : ");
             String f_id = input.nextLine(); 
                         
             String sql = "DELETE FROM Food WHERE FoodID = '"+f_id+"' ";
                    
            stm.executeUpdate(sql);
             System.out.println("Success'!");
    }
    
     catch (SQLException e){
            System.err.println(e);
        }
                break;
            }
            case 4: {
               // markComplete();
               
    try{
      
            Statement stm = (Statement) conn.createStatement();
             Scanner input = new Scanner(System.in);
             System.out.println("Enter The Order ID to Mark it Complete: ");
             String O_id = input.nextLine(); 
             String sql = "UPDATE Orders SET IsComplete = 'YES' where OrderID= '"+O_id+"' ";          

                    
            stm.executeUpdate(sql);
             System.out.println("Success'!");
    }
    
            catch (SQLException e){
            System.err.println(e);
            }
            break;
            }
            
            case 5: {
                //show_incompleteOrders();
                try{
   
            Statement stm = (Statement) conn.createStatement();
            String sql = "SELECT * FROM Orders where IsComplete = 'NO'";
            ResultSet rs= stm.executeQuery(sql);
            while (rs.next()){
                System.out.print(rs.getString("OrderID"));
                System.out.print(" | ");
                System.out.print(rs.getString("FoodID"));
                System.out.print(" | ");
                System.out.print(rs.getString("Price"));
                System.out.print(" | ");
                System.out.print(rs.getString("Otype"));
                System.out.print(" | ");
                System.out.print(rs.getString("Address"));
                System.out.print(" | ");
                System.out.print(rs.getString("DeliveryTime"));
                System.out.print(" | ");
                System.out.print(rs.getString("IsComplete"));
                System.out.print(" | ");
                System.out.println("");
            }

                    
            stm.executeQuery(sql);
             System.out.println("Success'!");
    }
    
     catch (SQLException e){
            System.err.println(e);
        }
                break;
            }
            default:
                System.out.println("Invalid Option");
        }
    
    }
 }
