unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    LabeledEdit1: TLabeledEdit;
    LabeledEdit2: TLabeledEdit;
    LabeledEdit3: TLabeledEdit;
    Memo1: TMemo;
    Label1: TLabel;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  a, b, hx, x, result, temp: real;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
x:=0.1;
 a:=StrToFloat(Form1.LabeledEdit1.Text);
 b:=StrToFloat(Form1.LabeledEdit2.Text);
 hx:=StrToFloat(Form1.LabeledEdit3.Text);
 Form1.Memo1.Lines.Add('Таблица значений');
 Form1.Memo1.Lines.Add('Х   /     У');
 if (a-b)<=0 then
 ShowMessage('Недопустимые значения переменных')
 else begin
 temp:=Ln(a-b);
  while x<=7.8 do begin
   if temp<x then  begin
   result:=17.3*(x-b)-exp(-2*a*x);
   Form1.Memo1.Lines.Add(FloatToStr(x) + '/' + FloatToStr(result));
   end
   else  begin
   result:=4.32*sqrt(abs(a*b*x)+abs(cos(x)));
  Form1.Memo1.Lines.Add(FloatToStr(x) + '/' + FloatToStr(result));
  end;
  x:=x+hx;
  end;
  end;
  end;
end.
