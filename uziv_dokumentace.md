# LinqBatch - uživatelská dokumentace

## Úvod a motivace
LinqBatch vznikl jako snaha rozšířit běžné Linq operace o úroveň výše než jen
pro běžné 1D pole/listy/atd. BatchLinq obsahuje podmnožinu nejběžnějších Linq operací
nad takzvanými "jagged" poli - lidově řečeno poli polí `[][]`. Základní myšlenka je provádět
operace nad individuálními vnitřními poli, chápanými jako batches dat.

## Popis operací
Všechny BatchLinq operace jsou pojmenovány stejně jako jejich běžné protějšky na 1D kolekcích,
s přidaným prefixem Batch (tedy `BatchSelect, BatchWhere, BatchMin/Max...`).
Všechny operace se musí používat metodou Fluent Syntax (`collection.BatchWhere().BatchMax()...`).

### BatchSelect
Argumenty: jagged kolekce, selektor dat
Návratový typ: `IEnumerable<Result[]>`
Základní operace Linq. Zde namísto 1D `IEnumerable<T>` počítáme s jagged kolekcí (`IE<IE<T>>`).
Příklad:
```cs
    string[][] example = [["apple","pear"]["banana"]];
    var result = example.BatchSelect(x => x.Length); // = ((5,4),(6))
```

### BatchWhere
Argumenty: jagged kolekce, podmínka
Návratový typ: `IEnumerable<IEnumerable<T>>`
Operace Where slouží jako podmínka/filtr kolekce, podmínka se předává v podobě lambda expression
Příklad:
```cs
    string[][] example = [["apple","pear"]["banana"]];
    var result = example.Where(x => x.Length > 4); // = (("apple"),("banana"))
```

### BatchMin/Max
Argumenty: jagged kolekce
Návratový typ: `IEnumerable<T>`
Vrátí seznam maximálních/minimálních prvků pro každý batch
Příklad:
```cs
    int[][] example = [[1,5,7][0, -2]];
    var resultMin = example.BatchMin(); // = (1, -2)
    var resultMax = example.BatchMax(); // = (7, 0)
```

### TotalMin/Max
Argumenty: jagged kolekce
Návratový typ: `T`
Pokud bychom chtěli najít maximální/minimální prvek napříč celým [][]
Příklad:
```cs
    int[][] example = [[1,5,7][0, -2]];
    var resultMin = example.TotalMin(); // = -2
    var resultMax = example.TotalMax(); // = 7
```

### BatchSum/TotalSum
Argumenty: jagged kolekce
Návratový typ: `IEnumerable<T>` pro Batch, `T` pro Total
Spočítá sumu číselných typů napříč každým batchem/celou jagged kolekcí.
Příklad:
```cs
    int[][] example = [[1,5,7][0]];
    var sums = example.BatchSum();     // = (13, 0)
    var sumTotal = example.TotalSum(); // = 13
```

### BatchAverage/TotalAverage
Argumenty: jagged kolekce
Návratový typ: `IEnumerable<T>` pro Batch, `T` pro Total
Spočítá průměr číselných typů napříč každým batchem/celou jagged kolekcí.
Příklad:
```cs
    int[][] example = [[1,5,7][0]];
    var avgs = example.BatchAverage();     // = (4, 0)
    var avgTotal = example.TotalAverage(); // = 3
```

### BatchTake/BatchSkip
Argumenty: jagged kolekce, celočíselný počet
Návratový typ: `IEnumerable<IEnumerable<T>>`
Operace Take získá (maximálně) prvních n prvků v každém batchi.
Operace Skip naopak přeskočí prvních n prvků a získá zbytek.
Příklad:
```cs
    int[][] example = [[1,5,7,8,9][0,2]];
    var first3 = example.BatchTake(3);          // = ((1, 5, 7), (0, 2))
    var allexceptfirst3 = example.BatchSkip(3); // = ((8, 9), ())
```

### BatchOrderBy
2 varianty
Argumenty: jagged kolekce, selector klíče podle kterého setřídíme
Návratový typ: `IEnumerable<IEnumerable<T>>`
Operace setřídí každý batch podle dodaného selektoru, kterým zaměříme klíč k setřízení.
Příklad:
```cs
    string[][] example = [["apple", "pear", "banana"], ["car", "train", "bike"]];
    var orderedByAplhabet = example.BatchOrderBy(x => x);        // = (("apple","banana","pear"),("bike","car","train"))
    var orderedByLength   = example.BatchOrderBy(x => x.Length); // = (("pear","apple","banana"),("car","bike","train"))
```

Argumenty: jagged kolekce, selector klíče podle kterého setřídíme, `vlastní IComparer<T>`
Návratový typ: `IEnumerable<IEnumerable<T>>`
Podobně jako první varianta, ke třízení používáme dodaný `IComparer<T>`