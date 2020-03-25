struct MonoVTable
{
	void *klass;
	void *gc_desc;
	void *vtable[];
};

struct ListItem
{
	struct MonoVTable *vtable;
	struct ListItem *next;	
};

struct IntItem
{
	struct MonoVTable *vtable;
	struct ListItem *next;
	int wert;
};

struct ShortItem
{
	struct MonoVTable *vtable;
	struct ListItem *next;
	short wert;
};

int ListItem_get_wert (struct ListItem *thisListItem)
{
	return 0;
}

void IntItem_ctor (struct IntItem *thisIntItem, int v, struct ListItem *n)
{
	thisIntItem->wert = v;
	thisIntItem->next = n;
	return ;
}

int IntItem_get_wert (struct IntItem *thisIntItem)
{
	return thisIntItem->wert;
}

void ShortItem_ctor (struct ShortItem *thisShortItem, short v, struct ListItem *n)
{
	thisShortItem->wert = v;
	thisShortItem->next = n;
}

int ShortItem_get_wert (struct ShortItem *thisShortItem)
{
	return (int)thisShortItem->wert;
}

int sum (struct ListItem* l)
{
	int (*get_wert)(struct ListItem*);
	
	int rest = 0;

	if (l == 0)
	{
		return 0;
	}
	
	if (l == 0) exit(1);
	rest = sum (l->next);

	if (l == 0) exit(1);
	get_wert = (int(*)(struct ListItem*)) l->vtable->vtable[0];

	return rest + get_wert(l);
}

struct MonoVTable mono_vtable_ListItem = {0, 0, {ListItem_get_wert}};
struct MonoVTable mono_vtable_IntItem = {0, 0, {IntItem_get_wert}};
struct MonoVTable mono_vtable_ShortItem = {0, 0, {ShortItem_get_wert}};

int main ()
{
	struct ListItem *x;
	struct IntItem i1;
	struct IntItem i2;
	struct ShortItem s1;

	i1.vtable = &mono_vtable_IntItem;
	i2.vtable = &mono_vtable_IntItem;
	s1.vtable = &mono_vtable_ShortItem;

	IntItem_ctor (&i2, 30, 0);
	ShortItem_ctor (&s1, 20, (struct ListItem*) &i2);
	IntItem_ctor (&i1, 10, (struct ListItem*) &s1);

	x = (struct ListItem*) &i1;
		
	printf("%d\n", sum (x));
}
