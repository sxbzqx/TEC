export interface Resource {
  id: number;
  name: string;
  idOtd: string;
  idParent: number | null;
  /** 1 = замена, 2 = установка */
  priznak: string;
}
