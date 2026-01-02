package High_Level_Programming.Lab_2;

import java.awt.event.*;
import javax.swing.*;


public class MyFrame extends JFrame implements ActionListener{
    JLabel label1 = new JLabel();
    JLabel label2 = new JLabel();
    JLabel label3 = new JLabel();
    JButton button = new JButton();
    JTextField field1 = new JTextField();
    JTextField field2 = new JTextField();
    JTextField field3 = new JTextField();

    private final int VOLUME = 300;
    private final int[] FUEL_RATES = { 1, 4, 7, 9 };
    private final int[] WEIGHT_LIMITS = { 0, 500, 1000, 1500, 2000 };
    private final int WIDTH = 600;
    private final int HEIGHT = 300;

    public MyFrame() {

        label1.setText("<html>Расстояние от пункта A до пункта Б (в километрах):");
        label2.setText("<html>Расстояние от пункта Б до пункта С (в километрах):");
        button.setText("Расчёт");
        label3.setText("Вес груза (в килограммах):");
        label1.setBounds(0, 0, WIDTH/2, 60);
        label2.setBounds(0, 60, WIDTH/2, 60);
        label3.setBounds(0, 120, WIDTH/2, 60);
        button.setBounds(0, 180, WIDTH/2, 60);
        field1.setBounds(WIDTH/2, 0, WIDTH/2, 60);
        field2.setBounds(WIDTH/2, 60, WIDTH/2, 60);
        field3.setBounds(WIDTH/2, 120, WIDTH/2, 60);

        this.setTitle("Доставка груза");
        this.setBounds(500, 500, WIDTH, HEIGHT);
        this.setResizable(false);
        this.setLayout(null);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        this.add(label1);
        this.add(label2);
        this.add(label3);
        this.add(button);
        this.add(field1);
        this.add(field2);
        this.add(field3);

        button.addActionListener(this);
    }

    public void actionPerformed(ActionEvent e) {
        if(e.getSource()==button){
            String inputDistance1 = field1.getText();
            String inputDistance2 = field2.getText();
            String inputCargoWeight = field3.getText();
            String message = ""; 
            int fuel = 0;

            try {
                int distance1 = Integer.parseInt(inputDistance1);
                int distance2 = Integer.parseInt(inputDistance2);
                int cargoWeight = Integer.parseInt(inputCargoWeight);

                if (cargoWeight > 2000 || cargoWeight < 0 || distance1 < 0 || distance2 < 0) {
                    message = "ERROR";
                } else {
                    for (int i = 1; i < WEIGHT_LIMITS.length; i++) {
                        if (cargoWeight <= WEIGHT_LIMITS[i] && cargoWeight > WEIGHT_LIMITS[i - 1]) {
                            fuel = FUEL_RATES[i - 1];
                        }
                    }
                    System.out.println(fuel);
                    message = Task1.distance(distance1, distance2, fuel, VOLUME);
                }
            } catch (NumberFormatException ex) {
                ex.printStackTrace();
                message = "ERROR";
            }
            JOptionPane.showMessageDialog(null, message, "output", JOptionPane.PLAIN_MESSAGE);
        }
    }
}
