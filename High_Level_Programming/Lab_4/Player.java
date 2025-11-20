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

    // констуркторы
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

    // getter'ы и setter'ы
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

    // работа с инвентарём
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
        if (0 < number && number < 10) {
            items[number] = null;
            for (int i = number; i + 1 < maxSize; i++) {
                items[i] = items[i + 1];
            }
        } else {
            System.out.println("Нет такого предмета");
        }
    }

    public void deleteItemByItem(Item item) {
        items[item.getINdex()] = null;
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

    // Получении информации о объекте класса player
    public void getInfo() {
        System.out.printf("HP персонажа: %d\nСытость персонажа: %d\nНаличие эффекта: %b\n", HP, satiety, buff);
    }

    // Методы класса
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

        eatFood(food);
    }

    // метод поедания еды
    private void eatFood(Food food) {
        food.eaten();

        HP = Math.min(maxHP, food.getSaturationLevel());
        satiety = Math.min(maxSatiety, food.getFoodLevel());
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

    // метод поставить один блок из инвентаря
    public void setBlock(Block block) {
        if (block.getQuantity() > 0) {
            block.use();
            if (block.getQuantity() == 0) {
                deleteItemByIndex(block.getINdex());
            }
        } else {
            System.out.println("Не хватает предмета");
        }
    }

    // метод использования инструмента
    public void hit(Tool tool) {
        if (tool.getStrength() > 0) {
            tool.hit();
            if (tool.getStrength() == 0) {
                deleteItemByIndex(tool.getINdex());
            }
        } else {
            System.out.println("Предмет сломан");
        }
    }
}
