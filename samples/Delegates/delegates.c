typedef struct MonoVTable MonoVTable;

typedef struct _MonoThreadsSync MonoThreadsSync;

typedef struct {
	MonoVTable *vtable;
	MonoThreadsSync *synchronisation;
} MonoObject;

typedef struct _MonoDelegate
{
	MonoObject object;
	MonoObject *target_type;
	MonoObject *target;
	void *method_name;
	void *method_ptr;
	/* TODO: complete stuct
	/* void *delegate_trampoline; */
	/* void *method_info; */
} MonoDelegate;

typedef struct _MonoMulticastDelegate MonoMulticastDelegate;
struct _MonoMulticastDelegate
{
	MonoDelegate d;
	MonoMulticastDelegate *prev;
};

typedef struct _Number$Display
{
	MonoMulticastDelegate md;
} Number$Display;

typedef struct _Number Number;
struct _Number
{
    MonoObject object;
	unsigned short val;
	Number *pred;
	Number *succ;
};

typedef struct _Display
{
	MonoObject object;
	unsigned short count;
} Display;

void
delegate_ctor (MonoDelegate *d, MonoObject *target, void *method_ptr)
{
    d->target = target;
	d->method_ptr = method_ptr;
}

unsigned short
Number$Display$Invoke (Number$Display *obj, Number *v)
{
	if (obj->md.d.target)
	{

		unsigned short (*invoke)(MonoObject* obj, Number* v);

		invoke = (unsigned short (*)(MonoObject* obj, Number* v)) obj->md.d.method_ptr;

		return invoke(obj->md.d.target, v);
	}
	else
	{
		unsigned short (*invoke)(Number* v);

		invoke = (unsigned short (*)(Number* v)) obj->md.d.method_ptr;

		return invoke(v);
	}
}

void
Number$ctor (Number *obj, unsigned short val, Number *p, Number *s)
{
	obj->val = val;
	obj->pred = p;
	obj->succ = s;
}

unsigned short
Number$Value (Number *obj)
{
	return obj->val;
}

Number*
Number$Predecessor (Number *obj)
{
	return obj->pred;
}

Number*
Number$Successor (Number *obj)
{
	return obj->succ;
}

unsigned short
Number$show (Number *obj, Number$Display *showNumbers)
{
	return Number$Display$Invoke (showNumbers, obj);
}

void
Display$show (unsigned short val)
{
	printf ("%d\n", val);
}

unsigned short
Display$showPredecessor (Display *obj, Number *num)
{
	 Display$show (Number$Value (Number$Predecessor (num)));

    ++obj->count;

	return obj->count;
}

unsigned short
Display$showSuccessor (Display *obj, Number *num)
{
    Display$show (Number$Value (Number$Successor (num)));

    ++obj->count;

	return obj->count;
}

unsigned short
Display$sshow (Number *num)
{
    Display$show (Number$Value (num));

	return 1;
}

int
main ()
{
	Number four, five, six;

	Number$Display staticShow, showPred, showSucc;

	Display display;
	display.count = 0;

	Number$ctor (&four, 4, 0, 0);
	Number$ctor (&six, 6, 0, 0);
	Number$ctor (&five, 5, &four, &six);

	delegate_ctor ((MonoDelegate*)&staticShow, 0, Display$sshow);
	delegate_ctor ((MonoDelegate*)&showPred, (MonoObject*)&display, Display$showPredecessor);
	delegate_ctor ((MonoDelegate*)&showSucc, (MonoObject*)&display, Display$showSuccessor);

	Display$show (Number$show (&five, &staticShow));
	Display$show (Number$show (&five, &showPred));
	Display$show (Number$show (&five, &showSucc));
    
	return 0;    
}
