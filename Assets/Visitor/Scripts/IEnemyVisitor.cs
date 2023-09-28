public interface IEnemyVisitor
{
    void Visit(Enemy enemy);
    void Visit(Elf elf);
    void Visit(Ork ork);
    void Visit(Robot robot);
}
