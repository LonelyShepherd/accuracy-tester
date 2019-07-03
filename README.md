# accuracy-tester
Изработено од: Милош Спасовски 173180 и Никола Стојановиќ 162010

1.Опис на проектот
Целта на проектот е играчот да ги тестира своите прецепциони способности каде што има 3 начини на играње. 
Првиот начин е наречен *Letter Chase*, каде што целта на играчот е да го состави зборот даден на екран што побргу без да промаши една буква, ако промаши една буква се појавуваат резултати од играта. 
Вториот начин е наречен *Test your perceprion* каде што играчот за одредено време треба да ги исклика топките на екранот, исто така пред почетокот на играта има подесување на опции.
Третиот начин е играчот против компјутерот. Во овој мод имаме имплементирано AI кој размислува и пробува да го сосотави зборот пред играчот.

2. Упатство за користење
На [**Слика1**](https://ibb.co/5cPZn03) е прикажано главното мени на играта, каде се бираат начини или различни модови за играње со нивно објаснување.
Со кликање се бира одреден мод каде што по завршувањето на играта се појавува статус на играта со фукцијата `ShowStats();` како што е прикажано на слика [**Слика1.1**](https://ibb.co/1Z5pJRq), потоа може да изберете опција за Restart или Quit. Quit ве враќа на главното мени.

3.Имплементација на играта
Сите три мода се имплементирани така што секој мод има посебна форма.
 3.1 Класи кои се користени се:  `public class LetterBall` и `public class Ball`
 ```c#
 public class LetterBall
  {
   
    public LetterBall(Point position, Random random);
 
    void AssignPoints();
  
    public char GenerateLetter();
 
    public LetterBall(Point position, int radius, Color color);
   
    public void Hit(Point position);
 
    public bool Colide(LetterBall ball);

    private int distance(Point p1, Point p2);
    
    public void Draw(Graphics g);

    public bool Tick();
    }
 ```
     
Класата `LetterBall` се користи за модовите `Letter Chase` и `Versus Computer`, а класата `Ball` се користи само за модот `Test your Perception`. Во класата `LetterBall` се дефинирани сите фукнциоланисти на топките со букви како што е доделување на поени кое зависи од големината на радиусот, доделувањето на поените се прави со функцијата void `AssignPoints();`
Во оваа класа исто така се генерира буква со рандомизирана фукнцијата `GenerateLetter();` каде генерираната буква се испишува на     рандом топка. Класата `Ball` ги има сите исто фукнционалнисти како LetterBall, но без `GenerateLetter();` фукнцијата.
     
 3.2 Форми кои се присутни во проектот: `TimedMode.cs`, `VersusComputer.cs`, `Default.cs`
 ```c#
namespace AccuracyTester
{
  public partial class VersusComputer : Form
  {
   
    public void InitTimer()

    void pleaseWait(object sender, EventArgs e)
 
    void elapsed(object sender, EventArgs e)
 
    void generate(object sender, EventArgs e)
  
    void timer_Tick(object sender, EventArgs e)
  
    void ShowStats()

    public void SelectCorrect(Graphics g)
 
    private void Restart()
 
    public void SelectCorrectCPU(Graphics g)

    void GenerateWordPlayer()

    void GenerateWordCPU()

    private void VersusComputer_Paint(object sender, PaintEventArgs e)
}

 
 ```
Во формите се случува целата игра. Во формата `VersusComputer.cs` со функцијата `GenerateWordPlayer();` се генерира збор од листа на  зборови земена од веб и се испишува на екранот за играчот, потоа се повикува функцијата `GenerateWordCPU();` која исто работи како       `GenerateWordPlayer();` но оваа функција го генерира зборот на компјутерот.
Функцијата `SelectCorrect();` се извршува кога играчот ќе погоди една правилна буква откако ќе ја погоди букавата таа буква се          обојува жолто на дадениот збор. Исто така компјутерот ја користи функцијата `SelectCorrectCPU();` за да ги обои неговата погодена        буква со зелена боја.
Компјутерот ја користи фукнцијата `PleaseWait();` која му дава на компјутерот одредено време да погоди одредена буква.
Откако играчот ќе го заврши зборот пред компјутерот на се повикува функцијата `ShowStats();` [**Изглед на фукнција**](https://ibb.co/1Z5pJRq) каде што се појавуваат скорот и други статистики за колку добро играчот ја играл таа партија, ако пак победи компјутерот пак се повикува таа функција и корисникот е промтан дека тој изгубил. 
  




