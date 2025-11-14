package High_Level_Programming.Lab_4;

class Block extends Item{
    private boolean poln;
    

    public Block(String name, String id, int maxStackSize, boolean poln){
        super(name, id, maxStackSize);
            this.poln = poln;
    }
    
}
