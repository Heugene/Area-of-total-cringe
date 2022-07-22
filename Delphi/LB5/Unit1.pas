unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, ExtCtrls;

type
  TForm1 = class(TForm)
    strgrM: TStringGrid;
    strgrB: TStringGrid;
    Button1: TButton;
    LabeledEdit1: TLabeledEdit;
    LabeledEdit2: TLabeledEdit;
    Button2: TButton;
    procedure FormCreate(Sender: TObject);
    procedure LabeledEdit1Exit(Sender: TObject);
    procedure LabeledEdit2Exit(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  ColC, RowC, i, g: byte;
  summa:  integer;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
 Form1.strgrM.Cells[0,0]:='¹';
 Form1.strgrB.Cells[0,0]:='¹';
 ColC:=(StrToInt(Form1.LabeledEdit1.Text));
 RowC:=(StrToInt(Form1.LabeledEdit2.Text));
  for i:=1 to 7 do begin
    Form1.strgrM.Cells[i,0]:=IntToStr(i);
  end;
  for i:=1 to 5 do begin
    Form1.strgrM.Cells[0,i]:=IntToStr(i);
  end;
  for i:=1 to ColC do begin
    Form1.strgrB.Cells[i,0]:=IntToStr(i);
  end;
end;

procedure TForm1.LabeledEdit1Exit(Sender: TObject);
begin
ColC:=(StrToInt(Form1.LabeledEdit1.Text));
  Form1.strgrM.ColCount:=ColC+1;
  Form1.strgrB.ColCount:=ColC+1;
  for i:=1 to ColC do begin
    Form1.strgrM.Cells[i,0]:=IntToStr(i);
  end;
  for i:=1 to ColC do begin
    Form1.strgrB.Cells[i,0]:=IntToStr(i);
  end;
end;

procedure TForm1.LabeledEdit2Exit(Sender: TObject);
begin
RowC:=(StrToInt(Form1.LabeledEdit2.Text));
  Form1.strgrM.RowCount:=RowC+1;
  for i:=1 to RowC do begin
    Form1.strgrM.Cells[0,i]:=IntToStr(i);
  end;
end;


procedure TForm1.Button2Click(Sender: TObject);
begin
randomize();
  for i:=1 to RowC do begin
    for g:=1 to ColC do begin
    Form1.strgrM.Cells[g,i]:=IntToStr(Random(11));
    end;
  end;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
summa:=0;
Form1.strgrB.Cells[0,1]:='check';
  for i:=1 to ColC do begin
    for g:=1 to (RowC-1) do begin
      summa:=StrToInt(Form1.strgrM.Cells[i,g])+StrToInt(Form1.strgrM.Cells[i,g+1]);
    end;
    if summa = 0 then
    Form1.strgrB.Cells[i,1]:='0'
    else
    Form1.strgrB.Cells[i,1]:='1'
  end;
end;

end.
