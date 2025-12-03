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
        Food Apple = new Food("Яблоко", "apple", 64, 1, 5, 2);
        Player Steve = new Player("Steve", 20, 5, false);
        Block block = new Block("Grass", "grass", 64, 1, true, false, false);
        Tool tool = new Tool("Pick", "pick", 2, 3, 4);
        Steve.addItem(tool);
        Steve.addItem(Apple);
        Steve.getInfoItems();
        Steve.drop(Apple);
        Steve.drop(Apple);
        Steve.addItem(block);
        Steve.getInfoItems();
    }
}