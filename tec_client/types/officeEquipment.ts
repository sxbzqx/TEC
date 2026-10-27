export interface OfficeEquipment {
  id: number;
  type: string;
  sourceId: number;
  invNum: string | null;
  name: string;
  networkName: string | null;
  phone: string | null;
  department: string | null;
  userDep: string | null;
  userFio: string | null;
  // Аппаратная часть
  cpu: string | null;
  ram1: string | null;
  ram2: string | null;
  hdd1: string | null;
  hdd2: string | null;
  video: string | null;
  monitor: string | null;
  optical: string | null;
  audio: string | null;
  speakers: string | null;
  // Оргтехника
  serialNumber: string | null;
  typeCartr: string | null;
  numZapr: string | null;
  typeSelen: string | null;
  replaceSelen: string | null;
  typeToner: string | null;
  kolToner: string | null;
  // Эксплуатация
  inputMonth: string | null;
  inputYear: string | null;
}