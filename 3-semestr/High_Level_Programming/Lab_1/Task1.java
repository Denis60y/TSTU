package High_Level_Programming.Lab_1;

import java.util.Scanner;

public class Task1 {
    public static void main(String[] args) {

        final double PRICE_PER_KILOMETER = 8.5;

        int end, start;
        double price;

        Scanner scanner = new Scanner(System.in);

        System.out.print("Начальные показания одометра: ");
        start = scanner.nextInt();
        System.out.print("Конечные показания одометра: ");
        end = scanner.nextInt();

        price = (end - start) * PRICE_PER_KILOMETER;

        System.out.printf("Вы проехали %d км. Из расчета 8 руб. 50 коп. за км, " +
                "стоимость проезда равна %d руб. %.0f коп.", end - start, (int) price, (price - (int)price) * 100);

        scanner.close();
    }
}
