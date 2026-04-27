package High_Level_Programming.Lab_4;

import javax.swing.*;
import java.awt.*;
import java.util.HashMap;
import java.util.Map;

public class MyFrame extends JFrame {
    private Player player;
    private JTextArea playerInfoArea;
    private JPanel inventoryPanel;

    // Поля для базовых атрибутов (всегда видимы)
    private JTextField nameField, idField, quantityField, stackField;
    private JComboBox<String> typeComboBox;

    // Панель для динамических атрибутов (меняется в зависимости от типа)
    private JPanel dynamicAttributesPanel;
    private Map<String, JTextField> dynamicFields;

    public MyFrame() {
        player = new Player("Стив", 20, 5, false);

        setTitle("Инвентарь");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(800, 750); // Увеличим высоту для динамической панели
        setLayout(new BorderLayout());

        add(createPlayerPanel(), BorderLayout.NORTH);

        inventoryPanel = new JPanel();
        inventoryPanel.setLayout(new BoxLayout(inventoryPanel, BoxLayout.Y_AXIS));
        JScrollPane scrollPane = new JScrollPane(inventoryPanel);
        scrollPane.setBorder(BorderFactory.createTitledBorder("Инвентарь"));
        add(scrollPane, BorderLayout.CENTER);

        add(createCreationPanel(), BorderLayout.SOUTH);

        updateUI();
    }

    // --- НАСТРОЙКА UI ---

    private JPanel createPlayerPanel() {
        JPanel topPanel = new JPanel(new BorderLayout());
        topPanel.setBorder(BorderFactory.createTitledBorder("Персонаж"));
        
        playerInfoArea = new JTextArea(4, 30);
        playerInfoArea.setEditable(false);
        playerInfoArea.setFont(new Font("Monospaced", Font.BOLD, 12));
        topPanel.add(new JScrollPane(playerInfoArea), BorderLayout.CENTER);

        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
        JButton milkButton = new JButton("Выпить молоко");
        milkButton.addActionListener(e -> {
            player.drinkMilk();
            updateUI();
            JOptionPane.showMessageDialog(this, "Вы выпили молоко. Эффекты сброшены.");
        });
        buttonPanel.add(milkButton);
        topPanel.add(buttonPanel, BorderLayout.EAST);

        return topPanel;
    }

    private JPanel createCreationPanel() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        mainPanel.setBorder(BorderFactory.createTitledBorder("Создание предметов"));

        // 1. Панель базовых атрибутов (GridBagLayout для ровного размещения)
        JPanel basePanel = new JPanel(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5);
        gbc.fill = GridBagConstraints.HORIZONTAL;

        nameField = new JTextField(10);
        idField = new JTextField(10);
        quantityField = new JTextField("1", 5);
        stackField = new JTextField("64", 5);

        typeComboBox = new JComboBox<>(new String[]{"Food", "Tool", "Block"});
        typeComboBox.addActionListener(e -> updateDynamicFields()); // Добавляем слушателя

        // Строка 1: Тип и Название
        gbc.gridx = 0; gbc.gridy = 0; basePanel.add(new JLabel("Тип:"), gbc);
        gbc.gridx = 1; basePanel.add(typeComboBox, gbc);
        gbc.gridx = 2; basePanel.add(new JLabel("Название:"), gbc);
        gbc.gridx = 3; basePanel.add(nameField, gbc);

        // Строка 2: ID и Макс. Стек
        gbc.gridx = 0; gbc.gridy = 1; basePanel.add(new JLabel("ID:"), gbc);
        gbc.gridx = 1; basePanel.add(idField, gbc);
        gbc.gridx = 2; basePanel.add(new JLabel("Макс. Стек:"), gbc);
        gbc.gridx = 3; basePanel.add(stackField, gbc);

        // Строка 3: Количество и Кнопка
        gbc.gridx = 0; gbc.gridy = 2; basePanel.add(new JLabel("Количество:"), gbc);
        gbc.gridx = 1; basePanel.add(quantityField, gbc);

        // 2. Панель динамических атрибутов (BoxLayout для вертикального размещения)
        dynamicAttributesPanel = new JPanel();
        dynamicAttributesPanel.setLayout(new BoxLayout(dynamicAttributesPanel, BoxLayout.Y_AXIS));
        dynamicAttributesPanel.setBorder(BorderFactory.createTitledBorder("Специфические атрибуты"));
        
        // 3. Кнопка Создать
        JButton createBtn = new JButton("СОЗДАТЬ ПРЕДМЕТ");
        createBtn.addActionListener(e -> createItem());
        
        mainPanel.add(basePanel);
        mainPanel.add(dynamicAttributesPanel);
        mainPanel.add(createBtn);

        updateDynamicFields(); // Инициализация динамических полей при старте
        return mainPanel;
    }

    // --- ДИНАМИЧЕСКИЙ ФУНКЦИОНАЛ ---

    /** Обновляет поля ввода в зависимости от выбранного типа предмета. */
    private void updateDynamicFields() {
        dynamicAttributesPanel.removeAll();
        dynamicFields = new HashMap<>();
        String type = (String) typeComboBox.getSelectedItem();

        if (type == null) return;
        
        // Используем GridLayout для размещения 2 колонки (метка + поле)
        JPanel grid = new JPanel(new GridLayout(0, 2, 10, 5));
        grid.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        switch (type) {
            case "Food" -> {
                addDynamicField(grid, "Насыщение (int)", "saturationLevel", "5");
                addDynamicField(grid, "Уровень еды (int)", "foodLevel", "2");
                addDynamicField(grid, "С чарами (bool)", "enchanted", "false");
            }
            case "Tool" -> {
                addDynamicField(grid, "Урон (int)", "damage", "5");
                addDynamicField(grid, "Макс. прочность (int)", "maxStrength", "100");
                addDynamicField(grid, "Прочность (int)", "strength", "100");
                addDynamicField(grid, "Мощность (int)", "power", "3");
            }
            case "Block" -> {
                addDynamicField(grid, "Полный блок (bool)", "full", "true");
                addDynamicField(grid, "Падающий блок (bool)", "fall", "false");
                addDynamicField(grid, "Прозрачный (bool)", "transparency", "false");
                addDynamicField(grid, "Прочность блока (int)", "strength", "1");
            }
        }
        
        dynamicAttributesPanel.add(grid);
        dynamicAttributesPanel.revalidate();
        dynamicAttributesPanel.repaint();
    }
    
    /** Вспомогательный метод для добавления полей */
    private void addDynamicField(JPanel panel, String labelText, String fieldKey, String defaultValue) {
        JTextField field = new JTextField(defaultValue, 10);
        dynamicFields.put(fieldKey, field);
        
        panel.add(new JLabel(labelText));
        panel.add(field);
    }

    // --- ФУНКЦИОНАЛ СОЗДАНИЯ ---

    private void createItem() {
        try {
            String type = (String) typeComboBox.getSelectedItem();
            String name = nameField.getText().trim();
            String id = idField.getText().trim();
            int quantity = Integer.parseInt(quantityField.getText().trim());
            int maxStack = Integer.parseInt(stackField.getText().trim());

            if (name.isEmpty() || id.isEmpty()) {
                JOptionPane.showMessageDialog(this, "Заполните Название и ID.", "Ошибка", JOptionPane.ERROR_MESSAGE);
                return;
            }

            Item newItem = switch (type) {
                case "Food" -> {
                    // Food: (name, id, maxStack, quantity, saturationLevel, foodLevel, enchanted)
                    int saturationLevel = Integer.parseInt(dynamicFields.get("saturationLevel").getText());
                    int foodLevel = Integer.parseInt(dynamicFields.get("foodLevel").getText());
                    boolean enchanted = Boolean.parseBoolean(dynamicFields.get("enchanted").getText());
                    yield new Food(name, id, maxStack, quantity, saturationLevel, foodLevel, enchanted);
                }
                case "Tool" -> {
                    // Tool: (name, id, damage, maxStrength, strength, power)
                    int damage = Integer.parseInt(dynamicFields.get("damage").getText());
                    int maxStrength = Integer.parseInt(dynamicFields.get("maxStrength").getText());
                    int strength = Integer.parseInt(dynamicFields.get("strength").getText());
                    int power = Integer.parseInt(dynamicFields.get("power").getText());
                    yield new Tool(name, id, damage, maxStrength, strength, power);
                }
                case "Block" -> {
                    // Block: (name, id, maxStack, quantity, full, fall, transparency, strength)
                    boolean full = Boolean.parseBoolean(dynamicFields.get("full").getText());
                    boolean fall = Boolean.parseBoolean(dynamicFields.get("fall").getText());
                    boolean transparency = Boolean.parseBoolean(dynamicFields.get("transparency").getText());
                    int strength = Integer.parseInt(dynamicFields.get("strength").getText());
                    yield new Block(name, id, maxStack, quantity, full, fall, transparency, strength);
                }
                default -> null;
            };

            if (newItem != null) {
                player.addItem(newItem);
                updateUI();
                // Очистка полей после успешного создания
                nameField.setText("");
                idField.setText("");
                quantityField.setText("1");
                JOptionPane.showMessageDialog(this, "Предмет \"" + name + "\" создан и добавлен.");
            }

        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(this, "Проверьте, что числовые поля (Количество, Стек, Насыщение, Прочность и т.д.) заполнены числами.", "Ошибка ввода", JOptionPane.ERROR_MESSAGE);
        } catch (IllegalArgumentException e) {
            JOptionPane.showMessageDialog(this, "Неверный ввод boolean (ожидается 'true' или 'false').", "Ошибка ввода", JOptionPane.ERROR_MESSAGE);
        } catch (Exception e) {
            JOptionPane.showMessageDialog(this, "Произошла ошибка при создании предмета: " + e.getMessage(), "Критическая ошибка", JOptionPane.ERROR_MESSAGE);
        }
    }

    // --- МЕТОДЫ ОБНОВЛЕНИЯ (БЕЗ ИЗМЕНЕНИЙ) ---
    
    private void updateUI() {
        updatePlayerInfo();
        updateInventoryList();
        revalidate();
        repaint();
    }

    private void updatePlayerInfo() {
        String info = String.format(
            "Имя: %s\nЗдоровье: %d/%d\nСытость: %d/%d\nБафф: %s",
            player.getName(),
            player.getHP(), 20, 
            player.getSatiety(), 10,
            player.getBuff() ? "ЕСТЬ" : "НЕТ"
        );
        playerInfoArea.setText(info);
    }

    private void updateInventoryList() {
        inventoryPanel.removeAll();
        Item[] items = player.getItems();

        for (int i = 0; i < items.length; i++) {
            Item item = items[i];
            if (item != null) {
                JPanel itemRow = createItemRow(item, i);
                inventoryPanel.add(itemRow);
                inventoryPanel.add(Box.createVerticalStrut(5));
            }
        }
    }

    private JPanel createItemRow(Item item, int index) {
        JPanel panel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        panel.setBorder(BorderFactory.createEtchedBorder());
        panel.setBackground(new Color(240, 240, 240));

        // Описание предмета
        String labelText = String.format("[%d] %s (x%d)", index + 1, item.getName(), item.getQuantity());
        
        if (item instanceof Tool tool) {
            // Исправленная строка
            labelText += String.format(" [Прочность: %d/%d]", tool.getStrength(), tool.getMaxStrength());
        }
        
        JLabel label = new JLabel(labelText);
        label.setPreferredSize(new Dimension(300, 20)); // Расширили метку
        panel.add(label);

        // Кнопка Инфо
        JButton infoBtn = new JButton("?");
        infoBtn.setToolTipText("Информация в консоль");
        infoBtn.addActionListener(e -> {
            System.out.println("\n--- Информация о предмете ---");
            try {
                item.getInfo(); 
            } catch (Exception ex) {
                System.out.println("Ошибка при выводе информации. Проверьте форматирование (например, %d/%s) в getInfo() Food.java.");
            }
            JOptionPane.showMessageDialog(this, "Информация выведена в консоль IDE");
        });
        panel.add(infoBtn);

        // Кнопка Использовать
        JButton useBtn = new JButton("Исп.");
        useBtn.addActionListener(e -> {
            if (item instanceof Food) player.useFood(item);
            else if (item instanceof Tool) player.useTool(item);
            else if (item instanceof Block) player.setBlock(item);
            updateUI(); 
        });
        panel.add(useBtn);

        // Кнопка Выбросить
        JButton dropBtn = new JButton("X");
        dropBtn.setBackground(new Color(255, 200, 200));
        dropBtn.addActionListener(e -> {
            player.drop(item);
            updateUI();
        });
        panel.add(dropBtn);

        return panel;
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            MyFrame frame = new MyFrame();
            frame.setVisible(true);
        });
    }
}