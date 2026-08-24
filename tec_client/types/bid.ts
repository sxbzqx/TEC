export interface Bid {
  id: number;
  idPerUser: number;
  idUser: string;
  idResource: number;
  amount: number | null;
  dateFirst: string;
  dateReshenie: string | null;
  userReshenie: string;
  commentReshenie: string;
  action: number;
  idReceiver: string;
  archive: number;
  comment: string | null;
  made: number;
  dateVyp: string | null;
  format: string;
}

/** 0 - на рассмотрении, 1 - разрешено, 2 - отклонено, 3 - отложено */
export type BidAction = 0 | 1 | 2 | 3;

export interface BidIncoming {
  id: number;
  dateFirst: string;
  idResource: number;
  resourceName: string;
  creatorName: string;
  creatorDepartment: string | null;
  amount: number | null;
  comment: string | null;
  action: BidAction;
  made: number;
  dateReshenie: string | null;
  commentReshenie: string | null;
  dateVyp: string | null;
}