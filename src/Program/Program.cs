using Library;

Dwarf enano = new Dwarf("Gimli", 100); //se crea un enano con nombre Gimli y vida 100
Item martilloDeGuerra = new Item("Martillo de Guerra", 15, 5,ItemType.Attack); //se crea un item con nombre Martillo de Guerra, ataque 15 y defensa 5
Item armaduraValiriana = new Item("Armadura Valiriana", 0, 20,ItemType.Defense); //se crea un item con nombre Armadura Valiriana, ataque 0 y defensa 20

enano.AddItem(martilloDeGuerra); //se añade el item Martillo de Guerra gimli
enano.AddItem(armaduraValiriana); //se añade el item Armadura Valiriana gimli

SpellTome SangreDracarica = new SpellTome("Sangre Dracárica", ItemType.Magic); //se crea un SpellTome con nombre Sangre Dracárica
Spell bolaDeFuego = new Spell("Bola de Fuego", 20);//se crea un hechizo con nombre Bola de Fuego y daño 20
Spell llamarada = new Spell("Llamarada", 15); //se crea un hechizo con nombre Llamarada y daño 15

SangreDracarica.AddSpell(bolaDeFuego); //se añade el hechizo Bola de Fuego al SpellTome Sangre Dracárica
SangreDracarica.AddSpell(llamarada); //se añade el hechizo Llamarada al SpellTome Sangre Dracárica

Wizard mago = new Wizard("Gandalf", 100, SangreDracarica); //se crea un mago con nombre Gandalf, vida 100 y se le asigna el SpellTome Sangre Dracárica
Item baston = new Item("Bastón Mágico", 10, 0,ItemType.MagicAttack); //se crea un item con nombre Bastón Mágico, ataque 10 y defensa 3
Item capa = new Item("Capa Mágica", 0, 10,ItemType.Defense); //se crea un item con nombre Capa Mágica, ataque 0 y defensa 10

mago.AddItem(baston); //se añade el item Bastón Mágico a gandalf
mago.AddItem(capa); //se añade el item Capa Mágica a gandalf

SpellTome CorazonHelado = new SpellTome("Corazón Helado", ItemType.Magic); //se crea un SpellTome con nombre Corazón Helado
Spell Nevada = new Spell("Tormenta de Nieve", 20); //se crea un hechizo con nombre Tormenta de Nieve y daño 20
Spell picosH = new Spell("Picos Helados", 15); //se crea un hechizo con nombre Picos Helados y daño 15

CorazonHelado.AddSpell(Nevada); //se añade el hechizo Tormenta de Nieve al SpellTome Corazón Helado
CorazonHelado.AddSpell(picosH); //se añade el hechizo Picos Helados al SpellTome Corazón Helado

Wizard mago1 = new Wizard("Sauron", 100, CorazonHelado); //se crea un mago con nombre Sauron, vida 100 y se le asigna el SpellTome Corazón Helado
Item bastonGigante = new Item("Bastón de Hielo", 10, 3,ItemType.MagicAttack);//se crea un item con nombre Bastón de Hielo, ataque 10 y defensa 3
Item capain = new Item("Capa de Sigilo", 0, 10,ItemType.Defense);//se crea un item con nombre Capa de Sigilo, ataque 0 y defensa 10

mago1.AddItem(bastonGigante); //se añade el item Bastón de Hielo a Sauron
mago1.AddItem(capain); //se añade el item Capa de Sigilo a Sauron

Elf elfo = new Elf("Legolas", 100); //se crea un elfo con nombre Legolas y vida 100
Item arco = new Item("Arco de yggdrasil", 10,1,ItemType.Attack); //se crea un item con nombre Arco de yggdrasil, ataque 12 y defensa 0
Item tunicaElfica = new Item("Túnica Élfica", 1, 8,ItemType.Defense); //se crea un item con nombre Túnica Élfica, ataque 0 y defensa 8

elfo.AddItem(arco); //se añade el item Arco de yggdrasil a Legolas
elfo.AddItem(tunicaElfica); //se añade el item Túnica Élfica a Legolas
mago.Attack(enano,baston); //gandalf ataca al Gimli
mago.UseSpell(bolaDeFuego, enano); //gandalf usa el hechizo Bola de Fuego contra Gimli
mago1.UseSpell(Nevada, mago); //Sauron usa el hechizo Tormenta de Nieve contra Gandalf
enano.Attack(elfo,martilloDeGuerra); //Gimli ataca a Legolas
elfo.Attack(mago1,arco); //Legolas ataca a Sauron
enano.Heal();