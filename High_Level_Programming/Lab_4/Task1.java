package High_Level_Programming.Lab_4;

/*ЛАБОРАТОРНАЯ РАБОТА №4
 * 
 * 
 * 
 * Автор: @Pitt0n
 * Дата создания: 08.11.2025
 * Версия: 0.0.7
 */


public class Task1 {
    public static void main(String[] args) {
        Food item1 = new Food("Яблоко", "apple", 64, 5, 5, 35);
        Player Steve = new Player(20, 10, false);
        Steve.getInfo();
    }
}