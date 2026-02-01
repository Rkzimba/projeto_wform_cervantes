CREATE TABLE IF NOT EXISTS public.cadastro (
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1),
    nome text NOT NULL,
    numero integer NOT NULL,
    CONSTRAINT cadastro_pkey PRIMARY KEY (id),
    CONSTRAINT cadastro_numero_check CHECK (numero > 0),
    CONSTRAINT cadastro_numero_key UNIQUE (numero)
);

ALTER TABLE public.cadastro OWNER TO postgres;

COMMENT ON TABLE public.cadastro IS 'Cadastro com campo texto (nome) e campo numérico (numero).';

CREATE TABLE IF NOT EXISTS public.operacoes (
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1),
    data_hora timestamp with time zone NOT NULL DEFAULT current_timestamp,
    tipo_operacao text NOT NULL,
    CONSTRAINT operacoes_pkey PRIMARY KEY (id)
);

ALTER TABLE public.operacoes OWNER TO postgres;

COMMENT ON TABLE public.operacoes IS 'Log das operações na tabela cadastro: Insert, Update, Delete com data/hora.';

CREATE OR REPLACE FUNCTION public.fn_operacoes()
RETURNS trigger
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO public.operacoes (data_hora, tipo_operacao)
    VALUES (current_timestamp, TG_OP);
    RETURN COALESCE(NEW, OLD);
END;
$$;

ALTER FUNCTION public.fn_operacoes() OWNER TO postgres;

DROP TRIGGER IF EXISTS tr_cadastro_log ON public.cadastro;

CREATE TRIGGER tr_cadastro_log
    AFTER INSERT OR UPDATE OR DELETE ON public.cadastro
    FOR EACH ROW
    EXECUTE FUNCTION public.fn_operacoes();
