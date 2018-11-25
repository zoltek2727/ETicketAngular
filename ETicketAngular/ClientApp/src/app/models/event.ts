export interface Event {
  public EventId: number;
  public EventName: string;
  public EventDescription: string;
  public EventStart: string;
  public EventEnd: string;
  public EventTicketPurchaseLimit: number;
  public PlaceId: number;
  public TourId: number;
  public HotelReservationId: number;
  public TransportReservationId: number;
} 
