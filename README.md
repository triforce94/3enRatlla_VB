import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.Scanner;


public class Menu {

    static Scanner llegir=new Scanner(System.in);
    static ArrayList<Futbolista> futbolistes = new ArrayList<>();
    
    public static void main(String[] args) throws IOException, ClassNotFoundException {
        
        int opcio;
        
        do{
            
        System.out.println("1.- Afegir futbolista");
        System.out.println("2.- Buscar futbolista");
        System.out.println("3.- Llistar futbolistes");
        System.out.println("4.- Guardar");
        System.out.println("5.- Llegir");
        System.out.println("6.- Modificar futbolista");
        System.out.println("0.- Sortir");
        
        opcio=llegir.nextInt();
        
        switch(opcio){
            case 1:
                afegirFutbolistes();
                break;  
            case 2:
                buscarFutbolistes();
                break;
            case 3:
                llistarFutbolistes();
                break;
            case 4:
                guardar();
                break;
            case 5:
                llegir();
                break;
            case 6:
                modificar();
                break;
            case 0:
                System.out.println("Adeu!");
                break;
            default:
                 System.out.println("Opcio incorrecta");
                 break;
        }
        
        }while (opcio!=0);

    }
    
    public static void afegirFutbolistes(){
        String Nom;
        int Dorsal;
        String Posicio;
        
        Futbolista aux;
        int i, N;

        do {
            System.out.print("Número de futbolistes? ");
            N = llegir.nextInt();
        } while (N < 0);
        llegir.nextLine(); 
        for (i = 1; i <= N; i++) {

            System.out.println("Futbolista " + i);
            System.out.print("Nom: ");
            Nom = llegir.nextLine();
            System.out.print("Posició: ");
            Posicio = llegir.nextLine();
            System.out.print("Dorsal: ");
            Dorsal = llegir.nextInt();
            llegir.nextLine(); 
            
            aux = new Futbolista(); 
            
            aux.setNom(Nom);
            aux.setPosicio(Posicio);
            aux.setDorsal(Dorsal);
            
            futbolistes.add(aux);
        }
    }

    public static void buscarFutbolistes(){
        int dorsal;
        System.out.print("Introdueix el dorsal: ");
        dorsal = llegir.nextInt();
        System.out.println("Jugador amb el dorsal " + dorsal);
        for(int i = 0; i<futbolistes.size(); i++){
            if(futbolistes.get(i).getDorsal()==dorsal)
                System.out.println(futbolistes.get(i));
            else
                System.out.println("No s'han trobat coincidencies\n");
        }
    }
    
    public static void llistarFutbolistes(){
       
        for(int i = 0; i< futbolistes.size(); i++)
            System.out.println(futbolistes.get(i));
        
    }
    
    public static void guardar() throws FileNotFoundException, IOException {
        try{
            try (ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream("saveFutbolistes"))) {
                out.writeObject(futbolistes);
            }
            System.out.println("Fitxer guardat.\n");
        }
        catch(IOException e){
            System.out.println("Error."+e);
        }
    }
    

    public static void llegir() {
        try{
            try (ObjectInputStream fitxerIn = new ObjectInputStream(new FileInputStream("saveFutbolistes"))) {
                futbolistes = (ArrayList<Futbolista>) fitxerIn.readObject();
            }
            System.out.println("Fitxer obert.\n");
        }
        catch(Exception e){
            System.out.println("Error."+e);
        }
    }
    
    public static void modificar(){
        int dorsal;
        String posicio;
        
        System.out.print("Introdueix el dorsal: ");
        dorsal = llegir.nextInt();
        llegir.nextLine();
        for(int i = 0; i<futbolistes.size(); i++){
            if(futbolistes.get(i).getDorsal()==dorsal){
                System.out.println("Jugador "+futbolistes.get(i).getNom()+" amb el dorsal num."+futbolistes.get(i).getDorsal()+ " trobat!\n");
                System.out.println("Nova posicio: ");
                posicio = llegir.nextLine();
                futbolistes.get(i).setPosicio(posicio);
                System.out.println("Nou dorsal: ");
                dorsal = llegir.nextInt();
                futbolistes.get(i).setDorsal(dorsal);
            }
            else{
                System.out.println("No s'han trobat coincidencies\n");
            }
        }
    }
}