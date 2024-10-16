package practica_pc2;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class login {
    public static void main(String[] args) {

        // Declaración de variables
        final String correo = "admin@example.com";
        final String clave = "P@55w0rd";
        int intentos = 0;
        boolean acceso = false;

        //Pattern pattern = Pattern.compile("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6}$"); // Correo genérico
        //Pattern pattern = Pattern.compile("^[\\w._%+-]+@[\\w.-]+\\.[a-zA-Z]{2,6}$"); // Correo genérico
        Pattern pattern = Pattern.compile(correo); // Correo específico 

        // Creación del método Scanner
        Scanner sc = new Scanner(System.in);

        // Inicio del bucle while
            while (intentos < 5 && !acceso) {
            System.out.println("Ingrese su correo: ");
            String correoIngresado = sc.nextLine();
            System.out.println("Ingrese su clave: ");
            String claveIngresada = sc.nextLine();

            // Validación de credenciales con pattern y matching
            Matcher matcher = pattern.matcher(correoIngresado);
            if (matcher.matches() && claveIngresada.equals(clave)) {
                acceso = true;
            } else {
                System.out.println("Acceso denegado");
                intentos++;
            }
        }

        // Mensaje de bienvenida o cuenta suspendida
        if (acceso) {
            System.out.println("Bienvenido al sistema");
        } else {
            System.out.println("Cuenta suspendida");
        }

        // Cierre del método Scanner
        sc.close();
    }
}
