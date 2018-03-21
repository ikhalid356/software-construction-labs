package labsix;
import java.util.Scanner;
public class Labsix {

    /**
    * Function to check for uniqueness of registration number
    */
    public static boolean reg_check(int reg, int i, String[][] student){
        for (int j = 0; j < i; j++) {
            if (Integer.parseInt(student[j][1]) == reg)
                return true;
        }
        return false;
    }
    
    public static void print_stats(String[][] student){
        int sum = 0;
        int max = -1;
        int min = 99999;
        
        for (int i = 0; i < 6; i++) {
            System.out.println("Name: " + student[i][0]);
            System.out.println("Reg: " + student[i][1]);
            System.out.println("CGPA: " + student[i][2]);
            System.out.println("------------");
            int cgpa = Integer.parseInt(student[i][2]);
            sum = sum + Integer.parseInt(student[i][2]);
            if(cgpa < min) min = cgpa;
            if(cgpa > max) max = cgpa;
        }
        System.out.println("Average: " + sum/6);
        System.out.println("Max: " + max);
        System.out.println("Min: " + min);
        
        System.out.println("------------");
        System.out.println("Students with less than avg CGPA");
        for (int i = 0; i < 6; i++) {
            if (Integer.parseInt(student[i][2]) < (sum/6))
                System.out.println(student[i][0]);
        }
    }

    /**
    * Function to print various required statistics of the data
    */
     public static void check_stats(String[][] student){
         System.out.println("Enter registration number or name of any student: ");
         Scanner input = new Scanner(System.in);
         String inp = input.nextLine();
         
         boolean available = false;
         for (int i = 0; i < 6; i++) {
             // Comparison with both registration number and cgpa
             if (student[i][0].equals(inp) || student[i][1].equals(inp)){
                 available = true;
                 System.out.println("CGPA of this student: " + student[i][2]);
                 int rank = 1;
                 for (int j = 0; j < 6; j++) {
                     if(Integer.parseInt(student[j][2]) > Integer.parseInt(student[i][2]))
                         rank = rank + 1;
                 }
                 System.out.println("Rank of this student: " + rank);
             }  
         }
         if(!available)
             System.out.println("Data not available for this student");
     }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // Input student data
        // Index [i][0]: Name
        // Index [i][1]: Reg
        // Index [i][2]: CGPA
        String[][] student = new String[6][3];
        for(int i=0; i <6; i++){
            Scanner input = new Scanner(System.in);
            System.out.println("Enter your name: ");
            student[i][0] = input.nextLine();
            System.out.println("Enter your reg num: ");
            String reg = input.nextLine();
            while(reg_check(Integer.parseInt(reg), i, student)){
                System.out.println("Enter UNIQUE reg num: ");
                reg = input.nextLine();
            }
            student[i][1] = reg;
            System.out.println("Enter your cgpa: ");
            String cgpa = input.nextLine();
            while(Integer.parseInt(cgpa) < 0){
                System.out.println("Reenter your valid cgpa: ");
                cgpa = input.nextLine();
            }
            student[i][2] = cgpa;
        }
        // Call stat checking methods
        print_stats(student);
        check_stats(student);
    } 
}
