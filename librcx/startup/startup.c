extern void main (void);
extern void(*__ctors)(void);
extern void(*__ctors_end)(void);


/* entry point for brickOS */
void
_startup()
{
	void (**ctor)(void);    
    
    ctor = &__ctors;
    
    while (ctor < &__ctors_end)
	{        
        (*ctor) ();
        
		++ctor;
	}    
	
    main ();
    
    exit (0);
}
