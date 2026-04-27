package High_Level_Programming.Lab_5;

import High_Level_Programming.Lab_5.interfaces.Info;

abstract class Item implements Info{
    private String name;
    private String id;
    private int maxStackSize;
    private int quantity;
    private int index;

    // Конструкторы
    public Item(String name, String id, int maxStackSize, int quantity) {
        this.name = name;
        this.id = id;
        this.maxStackSize = maxStackSize;
        if (quantity > maxStackSize || quantity < 0) {
            this.quantity = maxStackSize;
            System.out.println("Количество предмета в ячейке не может превышать максимальное возможное количество или быть отрицательным");
        } else {
            this.quantity = quantity;
        }
    }

    public Item(String name, String id, int maxStackSize) {
        this.name = name;
        this.id = id;
        this.maxStackSize = maxStackSize;
        this.quantity = maxStackSize;
    }

    public Item(String name, String id) {
        this.name = name;
        this.id = id;
        this.maxStackSize = 64;
        this.quantity = 1;
    }

    // getter'ы и setter'ы
    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getId() {
        return id;
    }

    public void setMaxStackSize(int maxStackSize) {
        this.maxStackSize = maxStackSize;
    }

    public int getMaxStackSize() {
        return maxStackSize;
    }

    public void setQuantity(int quantity) {
        if (quantity < 0) {
            System.out.println("Количество не может быть отрицательным");
            return;
        }
        if (quantity > this.maxStackSize) {
            System.out.println("Количество предмета в ячейке не может превышать максимальное возможное количество");
            return;
        }
        this.quantity = quantity;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setIndex(int index) {
        this.index = index;
    }

    public int getIndex() {
        return index;
    }

    // Функция тотображения всей информации
    public void getInfo() {
        System.out.printf(
                "Название предмета: %s\nID предмета: %s\nМаксимальное количество в слоте: %d\nКоличество предметов в яцейке: %d\nЯчейка в инвентаре: %d\n",
                name, id, maxStackSize, quantity, index + 1);
    }

    // функция выбрасывания предмета
    public void abandoned() {
        quantity -= 1;
    }

    //абстрактный метод на использование предмета
    public abstract void useItem();
}
