package High_Level_Programming.Lab_3;

import java.awt.event.*;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;

import java.util.Random;

public class MyFrame extends JFrame implements ActionListener{
    JTable table;
    
    JTextField field1 = new JTextField();
    JTextField field2 = new JTextField();
    JTextField field3 = new JTextField();
    JTextField field4 = new JTextField();
    JComboBox<String> reservationComboBox = new JComboBox<>(); // Заменяем JTextField на JComboBox
    JTextField field6 = new JTextField();

    JButton buttonRandom = new JButton();
    JButton buttonGift = new JButton();
    JButton marketplaceButton = new JButton();
    JButton sumButton = new JButton();
    JButton reservationButton = new JButton();

    int SIZE = 10;
    Object[][] gifts = new Object[SIZE][5];
    
    Random random = new Random();
    
    String[] name = {"Книга в твёрдом переплёте", "Набор ароматических свечей", "Умная колонка", "Подарочный сертификат в книжный", "Качественные наушники", "Электронная книга", "Билет в кино", "Мягкий плед", "Настольная игра", "Кружка с подогревом", "Внешний аккумулятор", "Стильный блокнот и ручка", "Фитнес-браслет", "Набор для ухода за растениями", "Сертификат на мастер-класс", "Портативная колонка", "Магический шар предсказаний", "Хороший зонт", "Термос", "Косметичка", "Декоративная подушка", "Набор для пикника", "Ланч-бокс", "Копилка-головоломка", "Набор для рисования", "Пазл на 1000 деталей", "Флешка необычной формы", "Набор для выращивания трав", "Аромалампа с маслами", "Скретч-карта мира"};
    int[] price = {1000, 1500, 2000, 2500, 3000, 3200, 3500, 3700, 3800, 4000};
    String[] marketplace = {"Ozon", "Wildberries", "Яндекс Маркет", "AliExpress", "СберМегаМаркет"};
    String[] category = {"Новый год", "День рождения", "8 марта / 23 февраля", "Просто так", "На день святого Валентина"};
    Boolean[] reservation = {true, false};

    String[] columnNames = {"Название", "Цена", "Маркетплейс", "Категория", "Бронь"};

    DefaultTableModel tableModel = new DefaultTableModel(columnNames, 0);

    public MyFrame(){
        
        buttonRandom.setText("Случайный подарок");
        buttonRandom.addActionListener(this);
        buttonGift.setText("Создать подарок");
        buttonGift.addActionListener(this);
        marketplaceButton.setText("Подсчёт");
        marketplaceButton.addActionListener(this);
        sumButton.setText("Сумма");
        sumButton.addActionListener(this);
        reservationButton.setText("<html>Свободные подарки");
        reservationButton.addActionListener(this);

        this.setTitle("Доставка груза");
        this.setBounds(500, 500, 1000, 500);
        this.setResizable(false);
        this.setLayout(null);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        field1.setText("Подарок");
        field2.setText("Цена");
        field3.setText("Маркетплейс");
        field4.setText("Повод");
        reservationComboBox.addItem("true");
        reservationComboBox.addItem("false");
        reservationComboBox.setSelectedIndex(0); 
        field6.setText("Маркетплейс");
        
        RandomGifts(gifts, 0, SIZE);
    
        tableModel = new DefaultTableModel(gifts, columnNames);
    
        table = new JTable(tableModel);
    
        tableModel.addRow(RandomGift());

        field1.setBounds(10, 10, 150, 30);
        field2.setBounds(10, 50, 150, 30);
        field3.setBounds(10, 90, 150, 30);
        field4.setBounds(170, 10, 150, 30);
        reservationComboBox.setBounds(170, 50, 150, 30);
        field6.setBounds(500, 10, 150, 30);
        buttonGift.setBounds(170, 90, 150, 30);
        buttonRandom.setBounds(330, 10, 150, 30);
        sumButton.setBounds(330, 50, 150, 30);
        reservationButton.setBounds(330, 90, 150, 30);
        marketplaceButton.setBounds(670, 10, 150, 30);
        table.setBounds(10, 130, 970, 400);

        this.add(buttonRandom);
        this.add(marketplaceButton);
        this.add(buttonGift);
        this.add(sumButton);
        this.add(reservationButton);
        this.add(field1);
        this.add(field2);
        this.add(field3);
        this.add(field4);
        this.add(reservationComboBox);
        this.add(field6);
        this.add(table);
    }

    private void RandomGifts(Object[][] gifts, int i, int x) {
        gifts[i][0] = name[random.nextInt(name.length)];
        gifts[i][1] = price[random.nextInt(price.length)];
        gifts[i][2] = marketplace[random.nextInt(marketplace.length)];
        gifts[i][3] = category[random.nextInt(category.length)];
        gifts[i][4] = reservation[random.nextInt(reservation.length)];
        
        if(++i < x){
            RandomGifts(gifts, i, x);
        }
    }

    private Object[] RandomGift() {
        Object object[] = new Object[5];
        object[0] = name[random.nextInt(name.length)];
        object[1] = price[random.nextInt(price.length)];
        object[2] = marketplace[random.nextInt(marketplace.length)];
        object[3] = category[random.nextInt(category.length)];
        object[4] = reservation[random.nextInt(reservation.length)];
        
        return object;
    }

    public void actionPerformed(ActionEvent e) {
        if(e.getSource()==buttonRandom){
            Object[] newGift = RandomGift();

            tableModel.addRow(newGift);
        }
        if(e.getSource()==buttonGift){

            String giftName = field1.getText();
            String gidtPrice = field2.getText();
            String giftMarketplace = field3.getText();
            String giftCategory = field4.getText();
            String selectedReservation = (String) reservationComboBox.getSelectedItem();

            
            try {
                int priceGift = Integer.parseInt(gidtPrice);

                Object[] newGift = new Object[5];

                newGift[0] = giftName;
                newGift[1] = priceGift;
                newGift[2] = giftMarketplace;
                newGift[3] = giftCategory;
                newGift[4] = Boolean.parseBoolean(selectedReservation);


                tableModel.addRow(newGift);
            } catch (NumberFormatException ex) {
                ex.printStackTrace();
                JOptionPane.showMessageDialog(null, "ERROR", "output", JOptionPane.PLAIN_MESSAGE);
            }
        }
        if(e.getSource()==sumButton){
            int sum = 0;

            for (int i = 0; i < tableModel.getRowCount(); i++){
                sum += (int)tableModel.getValueAt(i, 1);
            }

            JOptionPane.showMessageDialog(null, "Сумма за все подарки:" + sum, "output", JOptionPane.PLAIN_MESSAGE);
        }
        if(e.getSource()==reservationButton){
            int count = 0;

            for (int i = 0; i < tableModel.getRowCount(); i++){
                if ((Boolean)tableModel.getValueAt(i, 4)){
                    count += 1;
                }
            }

            JOptionPane.showMessageDialog(null, "Количество свободных подарков:" + count, "output", JOptionPane.PLAIN_MESSAGE);
        }
        if(e.getSource()==marketplaceButton){
            int count = 0;
            String marketplaseGift = field6.getText();

            for (int i = 0; i < tableModel.getRowCount(); i++){
                if (tableModel.getValueAt(i, 2).equals(marketplaseGift)){
                    count += 1;
                }
            }

            JOptionPane.showMessageDialog(null, "Количество подарков с этого маркетплейса:" + count, "output", JOptionPane.PLAIN_MESSAGE);
        }
    }
}