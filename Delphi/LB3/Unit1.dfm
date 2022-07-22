object Form1: TForm1
  Left = 508
  Top = 297
  Width = 441
  Height = 310
  Caption = #1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072#1103' '#1088#1072#1073#1086#1090#1072'3 / '#1043#1077#1086#1082#1072' '#1045#1074#1075#1077#1085#1080#1081
  Color = clSkyBlue
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 16
    Top = 8
    Width = 394
    Height = 20
    Caption = #1042#1099#1095#1080#1089#1083#1077#1085#1080#1077' '#1090#1072#1073#1083#1080#1094#1099' '#1079#1085#1072#1095#1077#1085#1080#1081' '#1092#1091#1085#1082#1094#1080#1080' y=f(x)'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 40
    Width = 185
    Height = 185
    Caption = #1042#1074#1086#1076' '#1079#1085#1072#1095#1077#1085#1080#1081
    TabOrder = 0
    object LabeledEdit1: TLabeledEdit
      Left = 8
      Top = 48
      Width = 121
      Height = 21
      EditLabel.Width = 34
      EditLabel.Height = 13
      EditLabel.Caption = #1042#1074#1086#1076' '#1072
      TabOrder = 0
    end
    object LabeledEdit2: TLabeledEdit
      Left = 8
      Top = 96
      Width = 121
      Height = 21
      EditLabel.Width = 34
      EditLabel.Height = 13
      EditLabel.Caption = #1042#1074#1086#1076' b'
      TabOrder = 1
    end
    object LabeledEdit3: TLabeledEdit
      Left = 8
      Top = 144
      Width = 121
      Height = 21
      EditLabel.Width = 39
      EditLabel.Height = 13
      EditLabel.Caption = #1042#1074#1086#1076' hx'
      TabOrder = 2
    end
  end
  object Memo1: TMemo
    Left = 208
    Top = 48
    Width = 201
    Height = 177
    Lines.Strings = (
      '')
    ReadOnly = True
    ScrollBars = ssVertical
    TabOrder = 1
  end
  object Button1: TButton
    Left = 160
    Top = 240
    Width = 75
    Height = 25
    Caption = #1042#1099#1095#1080#1089#1083#1080#1090#1100
    TabOrder = 2
    OnClick = Button1Click
  end
end
