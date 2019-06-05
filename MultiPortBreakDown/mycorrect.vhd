# This file contains all kinds of functions and declerations which mostly do not change,
# we compare these parts with the file we recived to find errors.
# BTW. this string below indicates seperations of regions, please do not touch them.
# And! any comments must begin with '#'.
#
#This is the first part of the file:
library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;
--use work.global_package.all ;

package multi_ports_property   is   

constant    SDRAM_address_bits    : Integer := 29 ;       -- 27 for one Micron MT41J64M16LA, 28 for two Micron MT41J64M16LA, 29 for four Micron MT41J64M16LA
constant    SDRAM_data_bits       : Integer := 64 ;       -- 16 for one Micron MT41J64M16LA, 32 for two Micron MT41J64M16LA, 64 for four Micron MT41J64M16LA
constant    max_burst_size        : Integer := 8 ;

constant    UniPhy_data_bits      : Integer := SDRAM_data_bits *4 ; -- *4 for half clock rate, *8 for quarter clock rate
constant    SDRAM_type            : String  := "DDR_III" ;-- DDR_II,DDR_III
constant    full                  : Integer := 0 ;

-- ****************************************************************************
-- ports definition
-- ****************************************************************************
type        ports_name      is (
# Now begins a list of port names
0o0o0o0o0o0o0o0o0o0o0o0o0o00o0o0o0o0o0o00o0o0o0o0o0
# End of port name list
                            
                            last_pointer);
constant  number_of_ports  : integer := ports_name'pos(last_pointer) ;

type        SDRAM_port_types    is  (sequential,slow,random,sprint,manager) ; -- sprint is for read port only
type        Char                is  (A,B,R,W,Y,N) ;
type        one_port_properties_type    is record
                        name            :   ports_name ;            -- from the list above
                        valid           :   boolean ;               -- if false the port is not valid and will not generate
                        p_type          :   SDRAM_port_types ;      -- sequential,slow,sprint
                        R_W             :   Char ;                  -- R or W
                        data_size       :   Integer ;               -- 8, 16, 32, 64 or 128
                        bank            :   Char ;                  -- A or B
                        memory_size     :   Integer ;
                        memory_section  :   Integer ;               -- The order that the memory is divided to sections
                        relative_addr   :   boolean ;               -- 
                        priority        :   Integer ;
                        anable_emergency:   Char ;                  -- Y for enable emergency
                        read_back_addr  :   boolean ;               -- read back the address in debug read port only
            end record ;
type        ports_properties_type   is array(1 to number_of_ports) of one_port_properties_type ;

constant    ports_properties        : ports_properties_type := (
--------------------------------------------------------------------------------------------------------------------------------
-- |name                   |valid      |p_type         |R_W |data |bank| memory_size |memory |relative|prior|anable|read_bk|
-- |                       |           |               |    |size |    |             |section|address |ity  |emerge|address|
--------------------------------------------------------------------------------------------------------------------------------
# Beginning of register definitions
0o0o0o0o0o0o0o0o0o0o0o0o0o00o0o0o0o0o0o00o0o0o0o0o0
# End of definitions
--------------------------------------------------------------------------------------------------------------------------------


-- ****************************************************************************
-- Functions & declarations
-- ****************************************************************************
function  bank_B_exist  return boolean ; 
function  manager_A_W_exist  return boolean ;
function  manager_A_R_exist  return boolean ;
function  manager_B_W_exist  return boolean ;
function  manager_B_R_exist  return boolean ;
function  port_valid  (name : ports_name) return boolean ;
function  name2index  (name : ports_name) return Integer ;
function  port_data_bits  (name : ports_name) return Integer ;
function  port_is_write  (name : ports_name) return boolean ;
function  port_is_read  (name : ports_name) return boolean ;
function  port_type  (name : ports_name) return SDRAM_port_types ;
function  relative_address  (name : ports_name) return boolean ;
function  multi_port_enable_emergency   (name : ports_name) return Std_Logic ;
function  multi_port_enable_emergency   (index : integer) return Std_Logic ;
function  next_port_select  (index : Integer ; bank : Char) return Integer ;
function  start_of_memory_section  (name : ports_name) return std_logic_vector ;
function  start_of_global_memory_section  (name : ports_name) return std_logic_vector ;
function  start_of_memory_section  (index  : Integer) return std_logic_vector ;
function  end_of_memory_section  (name : ports_name) return std_logic_vector ;
function  end_of_memory_section  (index  : Integer) return std_logic_vector ;
function  size_of_memory_section  (name : ports_name) return Integer ;
function  number_of_slow_A_W_ports  return Integer ;
function  number_of_fast_A_W_ports  return Integer ;
function  number_of_slow_A_R_ports  return Integer ;
function  number_of_fast_A_R_ports  return Integer ;
function  number_of_slow_B_W_ports  return Integer ;
function  number_of_fast_B_W_ports  return Integer ;
function  number_of_slow_B_R_ports  return Integer ;
function  number_of_fast_B_R_ports  return Integer ;
function  number_of_SDRAM_A_write_ports return Integer ;
function  number_of_SDRAM_A_read_ports return Integer ;
function  number_of_SDRAM_B_write_ports return Integer ;
function  number_of_SDRAM_B_read_ports return Integer ;
function  port_number  (name : ports_name) return Integer ;
function  port_number  (index : Integer) return Integer ;
function  fast_port_num2index  (p_number  : Integer ; r_w : Char ; bank : Char) return Integer ;
function  slow_port_num2index  (p_number  : Integer ; r_w : Char ; bank : Char) return Integer ;
function  log_port_data_bits (data_bits : integer) return integer ;

end multi_ports_property ;


package body multi_ports_property is

function  bank_B_exist  return boolean is
    variable  exist  : boolean ;
    begin
        exist := false ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = B and ports_properties(i).p_type /= manager then
                exist := true ;
                exit ;
            end if ;
        end loop ;
        return exist ;
    end function ;

function  manager_A_W_exist  return boolean is
    variable  exist  : boolean ;
    variable num     : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = A
              and ports_properties(i).R_W = W
              and ports_properties(i).p_type = slow then
                num := num + 1 ;
            end if ;
        end loop ;
        exist := false ;
        if num > 1 then
            for i in 1 to number_of_ports loop
                if ports_properties(i).valid and ports_properties(i).name = slow_manager_A_W then
                    exist := true ;
                    exit ;
                end if ;
            end loop ;
        end if ;
        return exist ;
    end function ;

function  manager_A_R_exist  return boolean is
    variable  exist  : boolean ;
    variable num     : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = A
              and ports_properties(i).R_W = R
              and ports_properties(i).p_type = slow then
                num := num + 1 ;
            end if ;
        end loop ;
        exist := false ;
        if num > 1 then
            for i in 1 to number_of_ports loop
                if ports_properties(i).valid and ports_properties(i).name = slow_manager_A_R then
                    exist := true ;
                    exit ;
                end if ;
            end loop ;
        end if ;
        return exist ;
    end function ;

function  manager_B_W_exist  return boolean is
    variable  exist  : boolean ;
    variable num     : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = B
              and ports_properties(i).R_W = W
              and ports_properties(i).p_type = slow then
                num := num + 1 ;
            end if ;
        end loop ;
        exist := false ;
        if num > 1 then
            for i in 1 to number_of_ports loop
                if ports_properties(i).valid and ports_properties(i).name = slow_manager_B_W then
                    exist := true ;
                    exit ;
                end if ;
            end loop ;
        end if ;
        return exist ;
    end function ;

function  manager_B_R_exist  return boolean is
    variable  exist  : boolean ;
    variable num     : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = B
              and ports_properties(i).R_W = R
              and ports_properties(i).p_type = slow then
                num := num + 1 ;
            end if ;
        end loop ;
        exist := false ;
        if num > 1 then
            for i in 1 to number_of_ports loop
                if ports_properties(i).valid and ports_properties(i).name = slow_manager_B_R then
                    exist := true ;
                    exit ;
                end if ;
            end loop ;
        end if ;
        return exist ;
    end function ;

function  port_valid  (name : ports_name) return boolean is
    variable index  : Integer ;
    begin
        index := 0 ;
        for i in 1 to number_of_ports loop
            if name  = ports_properties(i).name then
                index := i ;
                exit ;
            end if ;
        end loop ;
        return ports_properties(index).valid ;
    end function ;
            
function  name2index  (name : ports_name) return Integer is
    variable index  : Integer ;
    begin
        index := 0 ;
        for i in 1 to number_of_ports loop
            if name  = ports_properties(i).name then
                index := i ;
                exit ;
            end if ;
        end loop ;
        return index ;
    end function ;

function  port_data_bits  (name : ports_name) return Integer is
    variable index      : Integer ;
    variable num        : Integer ;
    begin
        index := name2index(name) ;
        num := ports_properties(index).data_size ;
        return num ;
    end function ;

function  port_is_write  (name : ports_name) return boolean is
    variable index      : Integer ;
    begin
        index := name2index(name) ;
        if ports_properties(index).valid = true and ports_properties(index).R_W = W then
            return true ;
        else
            return false ;
        end if ;
    end function ;

function  port_is_read  (name : ports_name) return boolean is
    variable index      : Integer ;
    begin
        index := name2index(name) ;
        if ports_properties(index).valid = true and ports_properties(index).R_W = R then
            return true ;
        else
            return false ;
        end if ;
    end function ;

function  port_type  (name : ports_name) return SDRAM_port_types is
    variable index      : Integer ;
    variable pr_type    : SDRAM_port_types ;
    begin
        index := name2index(name) ;
        pr_type := ports_properties(index).p_type ;
        return pr_type ;
    end function ;

function  relative_address  (name : ports_name) return boolean is
    variable index      : Integer ;
    variable relative   : boolean ;
    begin
        index := name2index(name) ;
        relative := ports_properties(index).relative_addr ;
        return relative ;
    end function ;

function  multi_port_enable_emergency   (name : ports_name) return Std_Logic is
    variable index      : Integer ;
    variable std        : Std_Logic ;
    begin
        index := name2index(name) ;
        if ports_properties(index).anable_emergency = Y then
            std := '1' ;
        elsif ports_properties(index).anable_emergency = N then
            std := '0' ;
        else
            std := 'X' ;
        end if ;
        return std ;
    end function ;

function  multi_port_enable_emergency   (index : Integer) return Std_Logic is
    variable std        : Std_Logic ;
    begin
        if ports_properties(index).anable_emergency = Y then
            std := '1' ;
        elsif ports_properties(index).anable_emergency = N then
            std := '0' ;
        else
            std := 'X' ;
        end if ;
        return std ;
    end function ;

function  next_port_select  (index : Integer ; bank : Char) return Integer is
    variable next_priorty  : Integer ;
    variable next_index    : Integer ;
    begin
        next_priorty := 100 ;
        next_index := 100 ;
        if index = 0 then
            for i in 1 to number_of_ports loop
                if ports_properties(i).valid and bank = ports_properties(i).bank
                and ports_properties(i).priority < next_priorty then
					if ports_properties(i).p_type = slow then
						if (ports_properties(i).R_W = W and ports_properties(i).bank = A and manager_A_W_exist)
						or (ports_properties(i).R_W = R and ports_properties(i).bank = A and manager_A_R_exist)
						or (ports_properties(i).R_W = W and ports_properties(i).bank = B and manager_B_W_exist)
						or (ports_properties(i).R_W = R and ports_properties(i).bank = B and manager_B_R_exist) then
							next ;
						end if ;
					end if ;
                    next_priorty := ports_properties(i).priority ;
                    next_index := i ;
                end if ;
            end loop ;
        else
            next_index := index ;    
            for i in 1 to number_of_ports loop
                if ports_properties(i).valid and bank = ports_properties(i).bank then
					if ports_properties(i).p_type = slow then
						if (ports_properties(i).R_W = W and ports_properties(i).bank = A and manager_A_W_exist)
						or (ports_properties(i).R_W = R and ports_properties(i).bank = A and manager_A_R_exist)
						or (ports_properties(i).R_W = W and ports_properties(i).bank = B and manager_B_W_exist)
						or (ports_properties(i).R_W = R and ports_properties(i).bank = B and manager_B_R_exist) then
							next ;
						end if ;
					end if ;
                    if ports_properties(i).priority = ports_properties(index).priority and i > index then
                        next_index := i ;
                        exit ;
                    elsif ports_properties(i).priority > ports_properties(index).priority
                    and ports_properties(i).priority < next_priorty then
                        next_priorty := ports_properties(i).priority ;
                        next_index := i ;
                    end if ;
                end if ;
            end loop ;
        end if ;
		if next_index = 100 then
			next_index := 0 ;
		end if ;
        return next_index ;
    end function ;
    
function  start_of_global_memory_section  (name : ports_name) return std_logic_vector is
    variable index      : Integer ;
    variable global_address  : std_logic_vector(SDRAM_address_bits downto 0) ;
    begin
        index := name2index(name) ;
        global_address(SDRAM_address_bits-1 downto 0) := start_of_memory_section(name) ;
        if ports_properties(index).bank = A then
            global_address(SDRAM_address_bits) := '0' ;
        else
            global_address(SDRAM_address_bits) := '1' ;
        end if ;
        return global_address ;
    end function ;

function  start_of_memory_section  (index : integer) return std_logic_vector is
    variable section    : Integer ;
    variable SOMS       : std_logic_vector(SDRAM_address_bits-1 downto 0) ;
    begin
        SOMS := (others => '0') ;
        section := 1 ;
        if ports_properties(index).memory_section = 0 or ports_properties(index).memory_size = full then
            SOMS := (others => '0') ;
        else
            while section < ports_properties(index).memory_section loop
                for i in 1 to number_of_ports loop
                    if ports_properties(i).memory_section = section and ports_properties(index).bank = ports_properties(i).bank then
                        SOMS := SOMS + ports_properties(i).memory_size ;
                        section := section + 1 ;
                        exit ;
                    elsif i = number_of_ports then  -- mis section
                        section := section + 1 ;
                    end if ;
                end loop ;
            end loop ;
        end if ;
        return SOMS ;
    end function ;

function  start_of_memory_section  (name : ports_name) return std_logic_vector  is
    variable index      : Integer ;
    variable section    : Integer ;
    variable SOMS       : std_logic_vector(SDRAM_address_bits-1 downto 0) ;
    begin
        index := name2index(name) ;
        SOMS := (others => '0') ;
        section := 1 ;
        if ports_properties(index).memory_section = 0 or ports_properties(index).memory_size = full then
            SOMS := (others => '0') ;
        else
            while section < ports_properties(index).memory_section loop
                for i in 1 to number_of_ports loop
                    if ports_properties(i).memory_section = section and ports_properties(index).bank = ports_properties(i).bank then
                        SOMS := SOMS + ports_properties(i).memory_size ;
                        section := section + 1 ;
                        exit ;
                    elsif i = number_of_ports then  -- mis section
                        section := section + 1 ;
                    end if ;
                end loop ;
            end loop ;
        end if ;
        return SOMS ;
    end function ;

function  end_of_memory_section  (name : ports_name) return std_logic_vector is
    variable index      : Integer ;
    variable EOMS       : std_logic_vector(SDRAM_address_bits downto 0) ;
    constant max_EOMS   : std_logic_vector(SDRAM_address_bits-1 downto 0) := (others => '1') ;
    begin
        index := name2index(name) ;
        EOMS := ('0' & start_of_memory_section(index)) + ports_properties(index).memory_size - 1 ;
        if  EOMS > ('0' & max_EOMS) or ports_properties(index).memory_size = full then
            EOMS := ('0' & max_EOMS) ;
        end if ;
        return EOMS(SDRAM_address_bits-1 downto 0) ;
    end function ;

function  end_of_memory_section  (index : integer) return std_logic_vector is
    variable EOMS       : std_logic_vector(SDRAM_address_bits downto 0) ;
    constant max_EOMS   : std_logic_vector(SDRAM_address_bits-1 downto 0) := (others => '1') ;
    begin
        EOMS := ('0' & start_of_memory_section(index)) + ports_properties(index).memory_size - 1 ;
        if  EOMS > ('0' & max_EOMS) or ports_properties(index).memory_size = full then
            EOMS := ('0' & max_EOMS) ;
        end if ;
        return EOMS(SDRAM_address_bits-1 downto 0) ;
    end function ;
    
function  size_of_memory_section  (name : ports_name) return Integer is
    variable index      : Integer ;
    variable size       : Integer ;
    begin
        index := name2index(name) ;
        size := ports_properties(index).memory_size ;
        return size ;
    end function ;
    
function  number_of_slow_A_W_ports  return Integer is
    variable num        : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = A
              and ports_properties(i).R_W = W
              and ports_properties(i).p_type = slow and manager_A_W_exist then
                num := num + 1 ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_fast_A_W_ports  return Integer is
    variable num        : Integer ;
    begin
        if not manager_A_W_exist or number_of_slow_A_W_ports = 0 then
            num := 0 ;
        else
            num := 1 ;
        end if ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).p_type /= manager then
                if ports_properties(i).valid and ports_properties(i).bank = A
                  and ports_properties(i).R_W = W
                  and (ports_properties(i).p_type /= slow or not manager_A_W_exist) then
                    num := num + 1 ;
                end if ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_slow_A_R_ports  return Integer is
    variable num        : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = A
              and ports_properties(i).R_W = R
              and ports_properties(i).p_type = slow and manager_A_R_exist then
                num := num + 1 ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_fast_A_R_ports  return Integer is
    variable num        : Integer ;
    begin
        if not manager_A_R_exist or number_of_slow_A_R_ports = 0 then
            num := 0 ;
        else
            num := 1 ;
        end if ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).p_type /= manager then
                if ports_properties(i).valid and ports_properties(i).bank = A
                  and ports_properties(i).R_W = R
                  and (ports_properties(i).p_type /= slow or not manager_A_R_exist) then
                    num := num + 1 ;
                end if ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_slow_B_W_ports  return Integer is
    variable num        : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = B
              and ports_properties(i).R_W = W
              and ports_properties(i).p_type = slow and manager_B_W_exist then
                num := num + 1 ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_fast_B_W_ports  return Integer is
    variable num        : Integer ;
    begin
        if not manager_B_W_exist or number_of_slow_B_W_ports = 0 then
            num := 0 ;
        else
            num := 1 ;
        end if ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).p_type /= manager then
                if ports_properties(i).valid and ports_properties(i).bank = B
                  and ports_properties(i).R_W = W
                  and (ports_properties(i).p_type /= slow or not manager_B_W_exist) then
                    num := num + 1 ;
                end if ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_slow_B_R_ports  return Integer is
    variable num        : Integer ;
    begin
        num := 0 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).valid and ports_properties(i).bank = B
              and ports_properties(i).R_W = R
              and ports_properties(i).p_type = slow and manager_B_R_exist then
                num := num + 1 ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_fast_B_R_ports  return Integer is
    variable num        : Integer ;
    begin
        if not manager_B_R_exist or number_of_slow_B_R_ports = 0 then
            num := 0 ;
        else
            num := 1 ;
        end if ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).p_type /= manager then
                if ports_properties(i).valid and ports_properties(i).bank = B
                  and ports_properties(i).R_W = R
                  and (ports_properties(i).p_type /= slow or not manager_B_R_exist) then
                    num := num + 1 ;
                end if ;
            end if ;
        end loop ;
        return num ;
    end function ;

function  number_of_SDRAM_A_write_ports return Integer is
    variable num        : Integer ;
    begin
        if manager_A_W_exist and number_of_slow_A_W_ports /= 0 then
            num := number_of_fast_A_W_ports + number_of_slow_A_W_ports -1 ;
        else
            num := number_of_fast_A_W_ports + number_of_slow_A_W_ports ;        
        end if ;
        return num ;
    end function ;

function  number_of_SDRAM_A_read_ports return Integer is
    variable num        : Integer ;
    begin
        if manager_A_R_exist and number_of_slow_A_R_ports /= 0 then
            num := number_of_fast_A_R_ports + number_of_slow_A_R_ports -1 ;
        else
            num := number_of_fast_A_R_ports + number_of_slow_A_R_ports ;        
        end if ;
        return num ;
    end function ;

function  number_of_SDRAM_B_write_ports return Integer is
    variable num        : Integer ;
    begin
        if manager_B_W_exist and number_of_slow_B_W_ports /= 0 then
            num := number_of_fast_B_W_ports + number_of_slow_B_W_ports -1 ;
        else
            num := number_of_fast_B_W_ports + number_of_slow_B_W_ports ;        
        end if ;
        return num ;
    end function ;

function  number_of_SDRAM_B_read_ports return Integer is
    variable num        : Integer ;
    begin
        if manager_B_R_exist and number_of_slow_B_R_ports /= 0 then
            num := number_of_fast_B_R_ports + number_of_slow_B_R_ports -1 ;
        else
            num := number_of_fast_B_R_ports + number_of_slow_B_R_ports ;        
        end if ;
        return num ;
    end function ;

function  port_number  (index : Integer) return Integer is
-- the port number is in order is fast numbers then slow numbers, bank A then bank B
    variable num        : Integer ;
    begin
        num := -1 ;
        if ports_properties(index).p_type /= manager and ports_properties(index).valid then
            if ports_properties(index).bank = A and ports_properties(index).R_W = W then
                for i in 1 to number_of_ports loop
					if i > index then
						exit ;
                    elsif ports_properties(i).valid and ports_properties(i).bank = A and ports_properties(i).R_W = W
                    and ports_properties(i).p_type /= manager
                    and ((ports_properties(i).p_type /= slow and ports_properties(index).p_type /= slow)
                      or (ports_properties(i).p_type = slow and ports_properties(index).p_type = slow)
                      or not manager_A_W_exist) then
                        num := num + 1 ;
                    end if ;
                end loop ;
                if ports_properties(index).p_type /= slow or not manager_A_W_exist then
                    num := num ;
                else
                    num := num + number_of_fast_A_W_ports -1 ;
                end if ;
            elsif ports_properties(index).bank = A and ports_properties(index).R_W = R then
                for i in 1 to number_of_ports loop
					if i > index then
						exit ;
                    elsif ports_properties(i).valid and ports_properties(i).bank = A and ports_properties(i).R_W = R
                    and ports_properties(i).p_type /= manager
                    and ((ports_properties(i).p_type /= slow and ports_properties(index).p_type /= slow)
                      or (ports_properties(i).p_type = slow and ports_properties(index).p_type = slow)
                      or not manager_A_R_exist) then
                        num := num + 1 ;
                    end if ;
                end loop ;
                if ports_properties(index).p_type /= slow or not manager_A_R_exist then
                    num := num ;
                else
                    num := num + number_of_fast_A_R_ports -1 ;
                end if ;
            elsif ports_properties(index).bank = B and ports_properties(index).R_W = W then
                for i in 1 to number_of_ports loop
					if i > index then
						exit ;
                    elsif ports_properties(i).valid and ports_properties(i).bank = B and ports_properties(i).R_W = W
                    and ports_properties(i).p_type /= manager
                    and ((ports_properties(i).p_type /= slow and ports_properties(index).p_type /= slow)
                      or (ports_properties(i).p_type = slow and ports_properties(index).p_type = slow)
                      or not manager_B_W_exist) then
                        num := num + 1 ;
                    end if ;
                end loop ;
                if ports_properties(index).p_type /= slow or not manager_B_W_exist then
                    num := num + number_of_SDRAM_A_write_ports ;
                else
                    num := num + number_of_SDRAM_A_write_ports + number_of_fast_B_W_ports -1 ;
                end if ;
            elsif ports_properties(index).bank = B and ports_properties(index).R_W = R then
                for i in 1 to number_of_ports loop
					if i > index then
						exit ;
                    elsif ports_properties(i).valid and ports_properties(i).bank = B and ports_properties(i).R_W = R
                    and ports_properties(i).p_type /= manager
                    and ((ports_properties(i).p_type /= slow and ports_properties(index).p_type /= slow)
                      or (ports_properties(i).p_type = slow and ports_properties(index).p_type = slow)
                      or not manager_B_R_exist) then
                        num := num + 1 ;
                    end if ;
                end loop ;
                if ports_properties(index).p_type /= slow or not manager_B_R_exist then
                    num := num + number_of_SDRAM_A_read_ports ;
                else
                    num := num + number_of_SDRAM_A_read_ports + number_of_fast_B_R_ports -1 ;
                end if ; 
            end if ;
        end if ;
        return num ;
    end function ;

function  port_number  (name : ports_name) return Integer is
-- the port number is in order is fast numbers then slow numbers
    variable index      : Integer ;
    variable num        : Integer ;
    begin
        index := name2index(name) ;
        num := port_number(index) ;
        return num ;
    end function ;

function  fast_port_num2index  (p_number  : Integer ; r_w : Char ; bank : Char) return Integer is
    variable  index  : Integer ;
    begin
        index := number_of_ports + 1 ;
        if bank = A and R_W = W and p_number = number_of_fast_A_W_ports -1 and manager_A_W_exist then
            for i in 1 to number_of_ports loop
                if ports_properties(i).bank = A and ports_properties(i).R_W = W and ports_properties(i).p_type = manager then
                    index := i ;
                    exit ;
                end if ;
            end loop ;
        elsif bank = A and R_W = R and p_number = number_of_fast_A_R_ports -1 and manager_A_R_exist then
            for i in 1 to number_of_ports loop
                index := number_of_ports ;
                if ports_properties(i).bank = A and ports_properties(i).R_W = R and ports_properties(i).p_type = manager then
                    index := i ;
                    exit ;
                end if ;
            end loop ;
        elsif bank = B and R_W = W and p_number = number_of_fast_B_W_ports + number_of_SDRAM_A_write_ports -1 and manager_B_W_exist then
            for i in 1 to number_of_ports loop
                index := number_of_ports ;
                if ports_properties(i).bank = B and ports_properties(i).R_W = W and ports_properties(i).p_type = manager then
                    index := i ;
                    exit ;
                end if ;
            end loop ;
        elsif bank = B and R_W = R and p_number = number_of_fast_B_R_ports + number_of_SDRAM_A_read_ports -1 and manager_B_R_exist then
            for i in 1 to number_of_ports loop
                index := number_of_ports ;
                if ports_properties(i).bank = B and ports_properties(i).R_W = R and ports_properties(i).p_type = manager then
                    index := i ;
                    exit ;
                end if ;
            end loop ;
        else
            for i in 1 to number_of_ports loop
                if ports_properties(i).R_W = r_w and port_number(i) = p_number and ports_properties(i).bank = bank then
                    index := i ;
                    exit ;
                end if ;
            end loop ;
        end if ;
        return index ;
    end function ;

function  slow_port_num2index  (p_number  : Integer ; r_w : Char ; bank : Char) return Integer is
    variable  index  : Integer ;
    begin
        index := number_of_ports + 1 ;
        for i in 1 to number_of_ports loop
            if ports_properties(i).R_W = r_w and port_number(i) = p_number and ports_properties(i).bank = bank then
                index := i ;
                exit ;
            end if ;
        end loop ;
        return index ;
    end function ;

function  log_port_data_bits (data_bits : integer) return integer is
    begin
        if    data_bits = 1   then return 0 ;
        elsif data_bits = 2   then return 1 ;
        elsif data_bits = 4   then return 2 ;
        elsif data_bits = 8   then return 3 ;
        elsif data_bits = 16  then return 4 ;
        elsif data_bits = 32  then return 5 ;
        elsif data_bits = 64  then return 6 ;
        elsif data_bits = 128 then return 7 ;
        elsif data_bits = 256 then return 8 ;
        elsif data_bits = 512 then return 9 ;
        elsif data_bits = 1024 then return 10 ;
        else return -1 ;
        end if ;
    end function ;


end multi_ports_property ;

-- **********************************************************************************************************************
-- **********************************************************************************************************************

library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;
use work.multi_ports_property.all;

package multi_ports_package   is   

constant  log_UniPhy_data_bits        : integer := log_port_data_bits(UniPhy_data_bits) ;
constant  log_max_burst_size          : integer := log_port_data_bits(max_burst_size) ;
constant  number_of_W_ports           : integer := number_of_SDRAM_A_write_ports + number_of_SDRAM_B_write_ports ;
constant  number_of_R_ports           : integer := number_of_SDRAM_A_read_ports + number_of_SDRAM_B_read_ports ;
subtype   burst_size_type             is std_logic_vector(log_port_data_bits(max_burst_size) downto 0) ;

subtype   SDRAM_W_port_type		      is Std_Logic_Vector(0 to number_of_W_ports-1) ;
subtype   SDRAM_R_port_type		      is Std_Logic_Vector(0 to number_of_R_ports-1) ;
type      SDRAM_write_address_type    is array(0 to number_of_W_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      SDRAM_read_address_type     is array(0 to number_of_R_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      SDRAM_write_data_type       is array(0 to number_of_W_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      SDRAM_read_data_type        is array(0 to number_of_R_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      SDRAM_wr_sprint_size        is array(0 to number_of_W_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      SDRAM_rd_sprint_size        is array(0 to number_of_R_ports-1) of Std_Logic_Vector(13 downto 0) ;

subtype   SDRAM_A_W_port_type		  is Std_Logic_Vector(0 to number_of_SDRAM_A_write_ports-1) ;
subtype   SDRAM_A_R_port_type		  is Std_Logic_Vector(0 to number_of_SDRAM_A_read_ports-1) ;
type      SDRAM_A_write_address_type  is array(0 to number_of_SDRAM_A_write_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      SDRAM_A_read_address_type   is array(0 to number_of_SDRAM_A_read_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      SDRAM_A_write_data_type     is array(0 to number_of_SDRAM_A_write_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      SDRAM_A_read_data_type      is array(0 to number_of_SDRAM_A_read_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      SDRAM_A_wr_sprint_size      is array(0 to number_of_SDRAM_A_write_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      SDRAM_A_rd_sprint_size      is array(0 to number_of_SDRAM_A_read_ports-1) of Std_Logic_Vector(13 downto 0) ;

subtype   SDRAM_B_W_port_type		  is Std_Logic_Vector(number_of_SDRAM_A_write_ports to number_of_W_ports-1) ;
subtype   SDRAM_B_R_port_type		  is Std_Logic_Vector(number_of_SDRAM_A_read_ports to number_of_R_ports-1) ;
type      SDRAM_B_write_address_type  is array(number_of_SDRAM_A_write_ports to number_of_W_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      SDRAM_B_read_address_type   is array(number_of_SDRAM_A_read_ports to number_of_R_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      SDRAM_B_write_data_type     is array(number_of_SDRAM_A_write_ports to number_of_W_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      SDRAM_B_read_data_type      is array(number_of_SDRAM_A_read_ports to number_of_R_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      SDRAM_B_wr_sprint_size      is array(number_of_SDRAM_A_write_ports to number_of_W_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      SDRAM_B_rd_sprint_size      is array(number_of_SDRAM_A_read_ports to number_of_R_ports-1) of Std_Logic_Vector(13 downto 0) ;

type      fast_A_read_address_type    is array(0 to number_of_fast_A_R_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      fast_A_read_data_type       is array(0 to number_of_fast_A_R_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      fast_A_rd_sprint_size       is array(0 to number_of_fast_A_R_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      fast_A_write_address_type   is array(0 to number_of_fast_A_W_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      fast_A_write_data_type      is array(0 to number_of_fast_A_W_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      fast_A_wr_sprint_size       is array(0 to number_of_fast_A_W_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      fast_B_read_address_type    is array(0 to number_of_fast_B_R_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      fast_B_read_data_type       is array(0 to number_of_fast_B_R_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      fast_B_rd_sprint_size       is array(0 to number_of_fast_B_R_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      fast_B_write_address_type   is array(0 to number_of_fast_B_W_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      fast_B_write_data_type      is array(0 to number_of_fast_B_W_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      fast_B_wr_sprint_size       is array(0 to number_of_fast_B_W_ports-1) of Std_Logic_Vector(13 downto 0) ;

type      slow_A_read_address_type    is array(0 to number_of_slow_A_R_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      slow_A_read_data_type       is array(0 to number_of_slow_A_R_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      slow_A_rd_sprint_size       is array(0 to number_of_slow_A_R_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      slow_A_write_address_type   is array(0 to number_of_slow_A_W_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      slow_A_write_data_type      is array(0 to number_of_slow_A_W_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      slow_A_wr_sprint_size       is array(0 to number_of_slow_A_W_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      slow_B_read_address_type    is array(0 to number_of_slow_B_R_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      slow_B_read_data_type       is array(0 to number_of_slow_B_R_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      slow_B_rd_sprint_size       is array(0 to number_of_slow_B_R_ports-1) of Std_Logic_Vector(13 downto 0) ;
type      slow_B_write_address_type   is array(0 to number_of_slow_B_W_ports-1) of Std_Logic_Vector(SDRAM_address_bits-1 downto 0) ;
type      slow_B_write_data_type      is array(0 to number_of_slow_B_W_ports-1) of Std_Logic_Vector(UniPhy_data_bits-1 downto 0) ;
type      slow_B_wr_sprint_size       is array(0 to number_of_slow_B_W_ports-1) of Std_Logic_Vector(13 downto 0) ;

end multi_ports_package ;



--*******************************************
-- synopsys translate_off 

library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;
use work.multi_ports_package.all ;
use work.multi_ports_property.all;


entity ports_test is 
    port (test_out : out integer) ;
end ports_test ;

architecture test of ports_test  is

signal      sum             : integer ;

type        ports_num_type  is array(1 to number_of_ports) of integer ;
signal      ports_num  : ports_num_type ;
signal      num_of_fast_w_a  : integer ;
signal      num_of_slow_w_a  : integer ;
signal      num_of_fast_r_a  : integer ;
signal      num_of_slow_r_a  : integer ;
signal      num_of_fast_w_b  : integer ;
signal      num_of_slow_w_b  : integer ;
signal      num_of_fast_r_b  : integer ;
signal      num_of_slow_r_b  : integer ;
signal      num_of_w_a       : integer ;
signal      num_of_r_a       : integer ;
signal      num_of_w_b       : integer ;
signal      num_of_r_b       : integer ;
type        index_type  is array(0 to number_of_ports-1) of integer ;
signal      fast_A_W_index   : index_type := (others => -1) ;
signal      fast_A_R_index   : index_type := (others => -1) ;
signal      fast_B_W_index   : index_type := (others => -1) ;
signal      fast_B_R_index   : index_type := (others => -1) ;
signal      clk              : Std_Logic := '0' ;


begin

clk <= '1' after 10 ns ;

test_p:  process (clk) is
begin
    if rising_edge(clk) then
        for i in 1 to number_of_ports loop
            ports_num(i) <= port_number(i) ;
            sum <= sum + port_number(i) ;
        end loop ;
        
        num_of_fast_w_a <= number_of_fast_A_W_ports ;
        num_of_slow_w_a <= number_of_slow_A_W_ports ;
        num_of_fast_r_a <= number_of_fast_A_R_ports ;
        num_of_slow_r_a <= number_of_slow_A_R_ports ;
        num_of_fast_w_b <= number_of_fast_B_W_ports ;
        num_of_slow_w_b <= number_of_slow_B_W_ports ;
        num_of_fast_r_b <= number_of_fast_B_R_ports ;
        num_of_slow_r_b <= number_of_slow_B_R_ports ;
        num_of_w_a      <= number_of_SDRAM_A_write_ports ;
        num_of_r_a      <= number_of_SDRAM_A_read_ports ;
        num_of_w_b      <= number_of_SDRAM_B_write_ports ;
        num_of_r_b      <= number_of_SDRAM_B_read_ports ;
        
        if number_of_fast_A_W_ports /= 0 then
            for i in 0 to number_of_fast_A_W_ports-1 loop
                fast_A_W_index(i) <= fast_port_num2index(i,W,A) ;
            end loop ;
        end if ;
        if number_of_fast_A_R_ports /= 0 then
            for i in 0 to number_of_fast_A_R_ports-1 loop
                fast_A_R_index(i) <= fast_port_num2index(i,R,A) ;
            end loop ;
        end if ;
        if number_of_fast_B_W_ports /= 0 then
            for i in 0 to number_of_fast_B_W_ports-1 loop
                fast_B_W_index(i) <= fast_port_num2index(i,W,B) ;
            end loop ;
        end if ;
        if number_of_fast_B_R_ports /= 0 then
            for i in 0 to number_of_fast_B_R_ports-1 loop
                fast_B_R_index(i) <= fast_port_num2index(i,R,B) ;
            end loop ;
        end if ;
        
        test_out <= sum ;
        end if ;
end process ;

end test ;
-- synopsys translate_on


# End of the file to compare