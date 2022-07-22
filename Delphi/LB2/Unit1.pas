unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, jpeg;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Edx: TEdit;
    Edb: TEdit;
    Xlbl: TLabel;
    Blbl: TLabel;
    RadioGroup1: TRadioGroup;
    userhint: TLabel;
    TaskImg: TImage;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  x, b, result: real;
implementation

{$R *.dfm}




procedure TForm1.Button1Click(Sender: TObject);
var fx, xb: real;
begin
  x:=StrToFloat(Form1.Edx.Text);
  b:=StrToFloat(Form1.Edb.Text);
  xb:=x*b;
    case Form1.RadioGroup1.ItemIndex of
    0: fx:= sin(x);
    1: fx:= x*x;
    2: fx:= exp(x);
    end;
  if (xb<10) and (xb>0.5) then
  result:= exp(fx-abs(b))
  else if (xb<0.5) and (xb>0.1) then
  result:= sqrt(abs(fx+b))
  else
  result:= 2*sqr(fx);
  Form1.Memo1.Lines.Clear;
  Form1.Memo1.Lines.Add('������������ ������ 2');
  Form1.Memo1.Lines.Add('����� �������');
  Form1.Memo1.Lines.Add('x='+Form1.Edx.Text);
  Form1.Memo1.Lines.Add('b='+Form1.Edb.Text);
  Form1.Memo1.Lines.Add('g='+FloatToStrF(result, ffFixed, 7 , 6));

end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Form1.Edx.Text:= '1';
  Form1.Edb.Text:= '1';
  Form1.RadioGroup1.ItemIndex:=0;
  Form1.Memo1.Lines.Add('Results');
end;

end.
