package High_Level_Programming.Lab_4;

class Player {
    // Поля класса
    private String name;
    private int maxHP;
    private int HP;
    private int maxSatiety;
    private int satiety;
    private boolean buff;
    private Item[] items;
    private final int maxSize = 10;
    private int cursor = 0;

    // ----- констуркторы -----
    public Player(String name, int maxHP, int HP, int maxSatiety, int satiety, boolean buff) {
        this.name = name;
        this.maxHP = maxHP;
        this.HP = HP;
        this.maxSatiety = satiety;
        this.satiety = satiety;
        this.buff = buff;
        this.items = new Item[this.maxSize];
    }

    public Player(String name, int HP, int satiety, boolean buff) {
        this.name = name;
        this.maxHP = 20;
        this.HP = HP;
        this.maxSatiety = 10;
        this.satiety = satiety;
        this.buff = buff;
        this.items = new Item[this.maxSize];
    }

    // ----- getter'ы и setter'ы -----
    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setHP(int HP) {
        this.HP = HP;
    }

    public int getHP() {
        return HP;
    }

    public void setSatiety(int satiety) {
        this.satiety = satiety;
    }

    public int getSatiety() {
        return satiety;
    }

    public void setBuff(boolean buff) {
        this.buff = buff;
    }

    public boolean getBuff() {
        return buff;
    }

    // ----- работа с инвентарём -----
    public void setItem(Item item, int number) {
        this.items[number] = item;
    }

    public Item getItemByIndex(int number) {
        return items[number];
    }

    public Item[] getItems() {
        return items;
    }

    public void addItem(Item item) {
        if (cursor < maxSize) {
            items[cursor] = item;
            item.setIndex(cursor);
            cursor++;
        } else {
            System.out.println("Инвентарь полон!");
        }
    }

    public void deleteItemByIndex(int number) {
        if (0 <= number && number < maxSize) {
            items[number].setIndex(-1);
            items[number] = null;
            for (int i = number; i + 1 < maxSize; i++) {
                items[i] = items[i + 1];
            }
        } else {
            System.out.println("Нет такого предмета");
        }
    }

    public void deleteItemByItem(Item item) {
        int index = item.getINdex();
        items[index].setIndex(-1);
        items[index] = null;
        for (int i = item.getINdex(); i + 1 < maxSize; i++) {
            items[i] = items[i + 1];
        }
    }

    public void getInfoItems() {
        for (int i = 0; i < cursor; i++) {
            if (items[i] != null) {
                items[i].getInfo();
                System.out.println("\n");
            } else {
                continue;
            }
        }
    }

    // ----- Методы класса-----
    // Метод выпить молоко и сбросить баффы
    public void drinkMilk() {
        this.buff = false;
    }

    // Метод проверки на возможность употребить еду
    public void useFood(Item item) {
        if (!(item instanceof Food food)) {
            System.out.println("Этот предмет нельзя съесть");
            return;
        }

        if (satiety >= maxSatiety) {
            System.out.println("Персонаж не голоден");
            return;
        }

        if (item.getQuantity() <= 0) {
            System.out.println("Не хватает предмета");
            return;
        }

        if (item.getINdex() == -1) {
            System.out.println("Предмета нет в инвентаре");
            return;
        }

        eatFood(food);
    }

    // метод поедания еды
    private void eatFood(Food food) {
        food.eaten();

        HP = Math.min(maxHP, HP + food.getSaturationLevel());
        satiety = Math.min(maxSatiety, satiety + food.getFoodLevel());
        buff = food.getEnchanted();

        if (food.getQuantity() == 0) {
            deleteItemByIndex(food.getINdex());
        }
    }

    // метод на выброс единицы предмета из инвентаря
    public void drop(Item item) {
        if (item.getQuantity() > 0) {
            item.abandoned();
            if (item.getQuantity() == 0) {
                deleteItemByIndex(item.getINdex());
            }
        } else {
            System.out.println("Не хватает предмета");
        }
    }

    // Метод проверки на возможность поставить
    public void setBlock(Item item) {
        if (!(item instanceof Block block)) {
            System.out.println("Предмет нельзя поставить");
            return;
        }

        if (item.getQuantity() <= 0) {
            System.out.println("Не хватает предмета");
            return;
        }

        putBlock(block);
    }

    // метод поставить один блок из инвентаря
    private void putBlock(Block block) {
        block.use();

        if (block.getQuantity() == 0) {
            deleteItemByIndex(block.getINdex());
        }
    }

    // Метод проверки на возможность использовать как инструмент
    public void useTool(Item item) {
        if (!(item instanceof Tool tool)) {
            System.out.println("Это не иструмент");
            return;
        }

        if (tool.getStrength() <= 0) {
            System.out.println("Предмет сломан");
            return;
        }

        hit(tool);
    }

    // метод использования инструмента
    private void hit(Tool tool) {
        tool.hit();
        if (tool.getStrength() == 0) {
            deleteItemByIndex(tool.getINdex());
        }
    }

    // Получении информации о объекте класса player
    public void getInfo() {
        System.out.printf(
                "Максимально HP персонажа: %d\nHP персонажа: %d\nМаксимальная сытость персонажа: %d\nСытость персонажа: %d\nНаличие эффекта: %b\n",
                maxHP, HP, maxSatiety, satiety, buff);
    }
}