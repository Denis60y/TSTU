package High_Level_Programming.Lab_5;

import javax.swing.*;
import java.awt.*;


public class MyFrame extends JFrame {
    private Player player;
    private JTextArea playerInfoArea;
    private JTextArea inventoryArea;
    private JPanel actionPanel;
    
    public MyFrame() {
        // Инициализация игрока
        player = new Player("Стив", 20, 5, false);
        
        // Настройка окна
        setTitle("Minecraft-like Inventory System");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(900, 600);
        setLayout(new BorderLayout());
        
        // Панель информации о персонаже (сверху)
        JPanel playerPanel = createPlayerPanel();
        add(playerPanel, BorderLayout.NORTH);
        
        // Панель инвентаря (центр)
        JPanel inventoryPanel = createInventoryPanel();
        add(inventoryPanel, BorderLayout.CENTER);
        
        // Панель действий (право)
        actionPanel = new JPanel();
        actionPanel.setLayout(new BoxLayout(actionPanel, BoxLayout.Y_AXIS));
        actionPanel.setBorder(BorderFactory.createTitledBorder("Действия"));
        actionPanel.setPreferredSize(new Dimension(200, 0));
        add(actionPanel, BorderLayout.EAST);
        
        // Панель создания предметов (низ)
        JPanel creationPanel = createCreationPanel();
        add(creationPanel, BorderLayout.SOUTH);
        
        // Обновляем отображение
        updatePlayerInfo();
        updateInventoryDisplay();
    }
    
    private JPanel createPlayerPanel() {
        JPanel panel = new JPanel(new GridLayout(1, 2, 10, 10));
        panel.setBorder(BorderFactory.createTitledBorder("Информация о персонаже"));
        
        playerInfoArea = new JTextArea(5, 30);
        playerInfoArea.setEditable(false);
        playerInfoArea.setFont(new Font("Monospaced", Font.PLAIN, 12));
        
        // Кнопка для молока
        JButton milkButton = new JButton("Выпить молоко (сброс баффов)");
        milkButton.addActionListener(e -> {
            player.drinkMilk();
            updatePlayerInfo();
            JOptionPane.showMessageDialog(this, "Баффы сброшены!");
        });
        
        panel.add(new JScrollPane(playerInfoArea));
        panel.add(milkButton);
        
        return panel;
    }
    
    private JPanel createInventoryPanel() {
        JPanel panel = new JPanel(new BorderLayout());
        panel.setBorder(BorderFactory.createTitledBorder("Инвентарь"));
        
        inventoryArea = new JTextArea(15, 40);
        inventoryArea.setEditable(false);
        inventoryArea.setFont(new Font("Monospaced", Font.PLAIN, 12));
        
        // Кнопка просмотра подробностей
        JButton detailsButton = new JButton("Показать подробности предмета");
        detailsButton.addActionListener(e -> showItemDetails());
        
        JPanel buttonPanel = new JPanel();
        buttonPanel.add(detailsButton);
        
        panel.add(new JScrollPane(inventoryArea), BorderLayout.CENTER);
        panel.add(buttonPanel, BorderLayout.SOUTH);
        
        return panel;
    }
    
    private JPanel createCreationPanel() {
        JPanel panel = new JPanel();
        panel.setBorder(BorderFactory.createTitledBorder("Создание предметов"));
        panel.setLayout(new FlowLayout());
        
        // Кнопки создания разных типов предметов
        JButton createFoodButton = new JButton("Создать еду");
        createFoodButton.addActionListener(e -> createFoodDialog());
        
        JButton createToolButton = new JButton("Создать инструмент");
        createToolButton.addActionListener(e -> createToolDialog());
        
        JButton createBlockButton = new JButton("Создать блок");
        createBlockButton.addActionListener(e -> createBlockDialog());
        
        panel.add(createFoodButton);
        panel.add(createToolButton);
        panel.add(createBlockButton);
        
        return panel;
    }
    
    private void createFoodDialog() {
        JDialog dialog = new JDialog(this, "Создание еды", true);
        dialog.setLayout(new GridLayout(6, 2, 5, 5));
        dialog.setSize(400, 300);
        
        JTextField nameField = new JTextField("Яблоко");
        JTextField idField = new JTextField("apple");
        JTextField maxStackField = new JTextField("64");
        JTextField quantityField = new JTextField("1");
        JTextField saturationField = new JTextField("5");
        JTextField foodLevelField = new JTextField("2");
        JCheckBox enchantedCheck = new JCheckBox("Зачарованная");
        
        dialog.add(new JLabel("Название:"));
        dialog.add(nameField);
        dialog.add(new JLabel("ID:"));
        dialog.add(idField);
        dialog.add(new JLabel("Макс. в стеке:"));
        dialog.add(maxStackField);
        dialog.add(new JLabel("Количество:"));
        dialog.add(quantityField);
        dialog.add(new JLabel("Насыщение:"));
        dialog.add(saturationField);
        dialog.add(new JLabel("Утоление голода:"));
        dialog.add(foodLevelField);
        dialog.add(new JLabel(""));
        dialog.add(enchantedCheck);
        
        JButton createButton = new JButton("Создать");
        createButton.addActionListener(e -> {
            try {
                Food food = new Food(
                    nameField.getText(),
                    idField.getText(),
                    Integer.parseInt(maxStackField.getText()),
                    Integer.parseInt(quantityField.getText()),
                    Integer.parseInt(saturationField.getText()),
                    Integer.parseInt(foodLevelField.getText()),
                    enchantedCheck.isSelected()
                );
                
                player.addItem(food);
                updateInventoryDisplay();
                updateActionButtons();
                dialog.dispose();
                JOptionPane.showMessageDialog(this, "Еда создана и добавлена в инвентарь!");
            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(dialog, "Ошибка в числовых полях!", "Ошибка", JOptionPane.ERROR_MESSAGE);
            }
        });
        
        dialog.add(createButton);
        dialog.setVisible(true);
    }
    
    private void createToolDialog() {
        JDialog dialog = new JDialog(this, "Создание инструмента", true);
        dialog.setLayout(new GridLayout(6, 2, 5, 5));
        dialog.setSize(400, 300);
        
        JTextField nameField = new JTextField("Кирка");
        JTextField idField = new JTextField("pickaxe");
        JTextField damageField = new JTextField("5");
        JTextField maxStrengthField = new JTextField("100");
        JTextField strengthField = new JTextField("100");
        JTextField powerField = new JTextField("3");
        
        dialog.add(new JLabel("Название:"));
        dialog.add(nameField);
        dialog.add(new JLabel("ID:"));
        dialog.add(idField);
        dialog.add(new JLabel("Урон:"));
        dialog.add(damageField);
        dialog.add(new JLabel("Макс. прочность:"));
        dialog.add(maxStrengthField);
        dialog.add(new JLabel("Прочность:"));
        dialog.add(strengthField);
        dialog.add(new JLabel("Мощность:"));
        dialog.add(powerField);
        
        JButton createButton = new JButton("Создать");
        createButton.addActionListener(e -> {
            try {
                Tool tool = new Tool(
                    nameField.getText(),
                    idField.getText(),
                    Integer.parseInt(damageField.getText()),
                    Integer.parseInt(maxStrengthField.getText()),
                    Integer.parseInt(strengthField.getText()),
                    Integer.parseInt(powerField.getText())
                );
                
                player.addItem(tool);
                updateInventoryDisplay();
                updateActionButtons();
                dialog.dispose();
                JOptionPane.showMessageDialog(this, "Инструмент создан и добавлен в инвентарь!");
            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(dialog, "Ошибка в числовых полях!", "Ошибка", JOptionPane.ERROR_MESSAGE);
            }
        });
        
        dialog.add(createButton);
        dialog.setVisible(true);
    }
    
    private void createBlockDialog() {
        JDialog dialog = new JDialog(this, "Создание блока", true);
        dialog.setLayout(new GridLayout(6, 2, 5, 5));
        dialog.setSize(400, 300);
        
        JTextField nameField = new JTextField("Камень");
        JTextField idField = new JTextField("stone");
        JTextField maxStackField = new JTextField("64");
        JTextField quantityField = new JTextField("10");
        JTextField strengthField = new JTextField("5");
        JCheckBox fullCheck = new JCheckBox("Полный", true);
        JCheckBox fallCheck = new JCheckBox("Падающий", false);
        JCheckBox transparentCheck = new JCheckBox("Прозрачный", false);
        
        dialog.add(new JLabel("Название:"));
        dialog.add(nameField);
        dialog.add(new JLabel("ID:"));
        dialog.add(idField);
        dialog.add(new JLabel("Макс. в стеке:"));
        dialog.add(maxStackField);
        dialog.add(new JLabel("Количество:"));
        dialog.add(quantityField);
        dialog.add(new JLabel("Прочность:"));
        dialog.add(strengthField);
        dialog.add(new JLabel(""));
        dialog.add(fullCheck);
        dialog.add(new JLabel(""));
        dialog.add(fallCheck);
        dialog.add(new JLabel(""));
        dialog.add(transparentCheck);
        
        JButton createButton = new JButton("Создать");
        createButton.addActionListener(e -> {
            try {
                Block block = new Block(
                    nameField.getText(),
                    idField.getText(),
                    Integer.parseInt(maxStackField.getText()),
                    Integer.parseInt(quantityField.getText()),
                    fullCheck.isSelected(),
                    fallCheck.isSelected(),
                    transparentCheck.isSelected(),
                    Integer.parseInt(strengthField.getText())
                );
                
                player.addItem(block);
                updateInventoryDisplay();
                updateActionButtons();
                dialog.dispose();
                JOptionPane.showMessageDialog(this, "Блок создан и добавлен в инвентарь!");
            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(dialog, "Ошибка в числовых полях!", "Ошибка", JOptionPane.ERROR_MESSAGE);
            }
        });
        
        dialog.add(createButton);
        dialog.setVisible(true);
    }
    
    private void updatePlayerInfo() {
        StringBuilder sb = new StringBuilder();
        sb.append("Имя: ").append(player.getName()).append("\n");
        sb.append("HP: ").append(player.getHP()).append("/20\n");
        sb.append("Сытость: ").append(player.getSatiety()).append("/10\n");
        sb.append("Бафф: ").append(player.getBuff() ? "Да" : "Нет").append("\n");
        
        playerInfoArea.setText(sb.toString());
    }
    
    private void updateInventoryDisplay() {
        StringBuilder sb = new StringBuilder();
        Item[] items = player.getItems();
        
        for (int i = 0; i < items.length; i++) {
            sb.append(String.format("%2d. ", i + 1));
            if (items[i] != null) {
                sb.append(String.format("%-15s (x%d)", items[i].getName(), items[i].getQuantity()));
                if (items[i] instanceof Tool tool) {
                    sb.append(String.format(" [%d/%d]", tool.getStrength(), tool.getMaxStrength()));
                }
            } else {
                sb.append("[Пусто]");
            }
            sb.append("\n");
        }
        
        inventoryArea.setText(sb.toString());
        updateActionButtons();
    }
    
    private void updateActionButtons() {
        actionPanel.removeAll();
        
        Item[] items = player.getItems();
        for (int i = 0; i < items.length; i++) {
            final int index = i;
            final Item item = items[i];
            
            if (item != null) {
                JPanel itemPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
                itemPanel.setBorder(BorderFactory.createEtchedBorder());
                
                JLabel itemLabel = new JLabel(item.getName() + " (x" + item.getQuantity() + ")");
                itemPanel.add(itemLabel);
                
                // Кнопка информации
                JButton infoButton = new JButton("ℹ");
                infoButton.setToolTipText("Информация");
                infoButton.addActionListener(e -> {
                    item.getInfo();
                    JOptionPane.showMessageDialog(this, 
                        "Информация выведена в консоль", 
                        "Информация о предмете", 
                        JOptionPane.INFORMATION_MESSAGE);
                });
                
                // Кнопка использования
                JButton useButton = new JButton("Исп.");
                useButton.setToolTipText("Использовать");
                useButton.addActionListener(e -> useItem(item));
                
                // Кнопка выбрасывания
                JButton dropButton = new JButton("Выбр.");
                dropButton.setToolTipText("Выбросить");
                dropButton.addActionListener(e -> {
                    player.drop(item);
                    updateInventoryDisplay();
                    updatePlayerInfo();
                });
                
                itemPanel.add(infoButton);
                itemPanel.add(useButton);
                itemPanel.add(dropButton);
                
                actionPanel.add(itemPanel);
            }
        }
        
        actionPanel.revalidate();
        actionPanel.repaint();
    }
    
    private void useItem(Item item) {
        if (item instanceof Food) {
            player.useFood(item);
            JOptionPane.showMessageDialog(this, "Еда использована!");
        } else if (item instanceof Tool) {
            player.useTool(item);
            JOptionPane.showMessageDialog(this, "Инструмент использован!");
        } else if (item instanceof Block) {
            player.setBlock(item);
            JOptionPane.showMessageDialog(this, "Блок поставлен!");
        } else {
            JOptionPane.showMessageDialog(this, 
                "Этот предмет нельзя использовать", 
                "Ошибка", 
                JOptionPane.WARNING_MESSAGE);
        }
        
        updateInventoryDisplay();
        updatePlayerInfo();
    }
    
    private void showItemDetails() {
        String input = JOptionPane.showInputDialog(this, 
            "Введите номер предмета (1-10):", 
            "Просмотр предмета", 
            JOptionPane.QUESTION_MESSAGE);
        
        if (input != null) {
            try {
                int index = Integer.parseInt(input.trim()) - 1;
                if (index >= 0 && index < 10) {
                    Item item = player.getItemByIndex(index);
                    if (item != null) {
                        JTextArea textArea = new JTextArea(10, 40);
                        textArea.setEditable(false);
                        textArea.setFont(new Font("Monospaced", Font.PLAIN, 12));
                        
                        // Сохраняем оригинальный System.out
                        java.io.PrintStream originalOut = System.out;
                        
                        // Перенаправляем вывод в текстовую область
                        java.io.ByteArrayOutputStream baos = new java.io.ByteArrayOutputStream();
                        System.setOut(new java.io.PrintStream(baos));
                        
                        // Вызываем getInfo()
                        item.getInfo();
                        
                        // Восстанавливаем оригинальный System.out
                        System.setOut(originalOut);
                        
                        textArea.setText(baos.toString());
                        
                        JOptionPane.showMessageDialog(this, 
                            new JScrollPane(textArea), 
                            "Детали предмета", 
                            JOptionPane.INFORMATION_MESSAGE);
                    } else {
                        JOptionPane.showMessageDialog(this, 
                            "Ячейка пуста", 
                            "Ошибка", 
                            JOptionPane.WARNING_MESSAGE);
                    }
                }
            } catch (NumberFormatException e) {
                JOptionPane.showMessageDialog(this, 
                    "Введите число от 1 до 10", 
                    "Ошибка", 
                    JOptionPane.ERROR_MESSAGE);
            }
        }
    }
    
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            MyFrame frame = new MyFrame();
            frame.setVisible(true);
        });
    }
}