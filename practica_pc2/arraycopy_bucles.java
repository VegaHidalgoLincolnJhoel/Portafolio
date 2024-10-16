package practica_pc2;

import java.util.Scanner;
/*Crear una copia de arreglos usando bucles */

public class arraycopy_bucles {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = 0;
        int[] arreglo1 = {n};
        int[] arreglo2 = new int[arreglo1.length];
        boolean exit = false;

        while (!exit) {
            System.out.println("Menu:");
            System.out.println("1. Crear arreglo");
            System.out.println("2. Mostrar arreglo 1");
            System.out.println("3. Copiar arreglo");
            System.out.println("4. Mostrar arreglo 2");
            System.out.println("5. Salir");
            System.out.print("Seleccione una opción: ");
            int option = sc.nextInt();

            switch (option) {
            case 1:
                System.out.print("Ingrese el tamaño del arreglo: ");
                n = sc.nextInt();
                arreglo1 = new int[n];
                arreglo2 = new int[n];
                System.out.println("Ingrese los elementos del arreglo:");
                for (int i = 0; i < n; i++) {
                System.out.print("Elemento " + (i + 1) + ": ");
                arreglo1[i] = sc.nextInt();
                }
                System.out.println("Arreglo creado.");
                break;
            case 2:
                System.out.print("Arreglo 1: ");
                for (int i = 0; i < arreglo1.length; i++) {
                System.out.print(arreglo1[i] + " ");
                }
                System.out.println();
                break;
            case 3:
                for (int i = 0; i < arreglo1.length; i++) {
                arreglo2[i] = arreglo1[i];
                }
                System.out.println("Arreglo copiado.");
                break;
            case 4:
                System.out.print("Arreglo 2: ");
                for (int i = 0; i < arreglo2.length; i++) {
                System.out.print(arreglo2[i] + " ");
                }
                System.out.println();
                break;
            case 5:
                exit = true;
                System.out.println("Saliendo...");
                break;
            default:
                System.out.println("Opción no válida. Intente de nuevo.");
            }
        }
        sc.close();
    }
}