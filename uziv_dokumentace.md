# LinqBatch - uživatelská dokumentace

## Úvod a motivace
LinqBatch vznikl jako snaha rozšířit běžné Linq operace o úroveň výše než jen
pro běžné 1D pole/listy/atd. BatchLinq obsahuje podmnožinu nejběžnějších Linq operací
nad takzvanými "jagged" poli - lidově řečeno poli polí `[][]`. Základní myšlenka je provádět
operace nad individuálními vnitřními poli, chápanými jako batches dat.

## Popis operací

Všechny BatchLinq operace jsou pojmenovány stejně jako jejich běžné protějšky na 1D kolekcích,
s přidaným prefixem Batch (tedy `BatchSelect, BatchWhere, BatchMin/Max...`).
Všechny operace se musí používat metodou Fluent Syntax (`collection.OpA().OpB()...`).

### BatchSelect
Argumenty: jagged kolekce, selektor dat
Návratový typ: `IEnumerable<IEnumerable<T>>`
Základní operace Linq. Zde namísto 1D `IEnumerable<T>` počítáme s jagged kolekcí (`IE<IE<T>>`).
Příklad:
```
    string[][] example = [["apple","pear"]["banana"]];
    var result = example.BatchSelect(x => x.Length);
    // result bude obsahovat hodnoty ((5,4),(6))
```

### BatchWhere
Argumenty: jagged kolekce, podmínka
Návratový typ: `IEnumerable<IEnumerable<T>>`
Operace Where slouží jako podmínka/filtr kolekce, podmínka se předává v podobě lambda expression

### BatchMin/Max
Argumenty: jagged kolekce
Návratový typ: `IEnumerable<T>`
Vrátí seznam maximálních/minimálních prvků pro každý batch

### TotalMin/Max
Argumenty: jagged kolekce
Návratový typ: `T`
Pokud bychom chtěli najít maximální/minimální prvek napříč celým [][]

### BatchSum/TotalSum
Argumenty: jagged kolekce
Návratový typ: `IEnumerable<T>` pro Batch, `T` pro Total
Spočítá sumu číselných typů napříč každým batchem/celou jagged kolekcí.

### BatchAverage/TotalAverage
Argumenty: jagged kolekce
Návratový typ: `IEnumerable<T>` pro Batch, `T` pro Total
Spočítá průměr číselných typů napříč každým batchem/celou jagged kolekcí.

### BatchTake/BatchSkip
Argumenty: jagged kolekce, celočíselný počet
Návratový typ: `IEnumerable<IEnumerable<T>>`
Operace Take získá (maximálně) prvních n prvků v každém batchi.
Operace Skip naopak přeskočí prvních n prvků a získá zbytek.

### BatchOrderBy
2 varianty
Argumenty: jagged kolekce, selector klíče podle kterého setřídíme
Návratový typ: `IEnumerable<IEnumerable<T>>`
Operace setřídí každý batch podle dodaného selektoru, kterým zaměříme klíč k setřízení.

Argumenty: jagged kolekce, selector klíče podle kterého setřídíme, `vlastní IComparer<T>`
Návratový typ: `IEnumerable<IEnumerable<T>>`
Podobně jako první varianta, ke třízení používáme dodaný `IComparer<T>`