struct MonoVtable{
	void *klass;
	void *gc_desc;
	void *data;
};

struct StaticMember
{
		struct MonoVtable *vtable;
		int val;
};

struct MonoVtable StaticMember_vtable;

struct StaticMember_Statics{
	int sval;
	StaticMember *mval;
	int bval;
};

void
cctor ()
{
	StaticMember_vtable.data = malloc(sizeof(struct StaticMember_statics));
	((struct StaticMember_Statics *)StaticMember_vtable.data)->sval = 17;
}

main()
{
	cctor();
	((struct StaticMember_Statics *)StaticMember_vtable.data)->mval = newobj(StaticMember_vtable, 12);
	((struct StaticMember_Statics *)StaticMember_vtable.data)->bval = 1;
}

