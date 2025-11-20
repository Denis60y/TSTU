package High_Level_Programming.Lab_4;

/*ЛАБОРАТОРНАЯ РАБОТА №4
 * 
 * 
 * 
 * Автор: @Pitt0n
 * Дата создания: 08.11.2025
 * Версия: 0.0.9
 */

public class Task1 {
    public static void main(String[] args) {
        Food Apple = new Food("Яблоко", "apple", 64, 2, 5, 35);
        Player Steve = new Player("Steve", 20, 5, false);
        Block block = new Block("Grass", "grass", true, false, false);
        Steve.getInfo();
        System.out.println("\n");
        Steve.addItem(block);
        Steve.addItem(Apple);
        Steve.getInfoItems();
        Steve.useFood(Apple);
        Steve.useFood(Apple);
        Steve.getInfoItems();
        Steve.getInfo();
    }
}